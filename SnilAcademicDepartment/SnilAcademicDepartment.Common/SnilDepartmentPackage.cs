using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;

namespace SnilAcademicDepartment.Common.Infrastructure
{
	public static class SnilPackage
	{
		/// <summary>
		///     Registers types method.
		/// </summary>
		/// <param name="container">
		///     The container for registration of dependencies.
		/// </param>
		public static void RegisterSnilTypes(Container container)
		{
			var path = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

			var directoryInfo = new DirectoryInfo(path ?? throw new InvalidOperationException());

			var assemblies = directoryInfo.GetFiles()
				.Where(item => item.Extension.ToLower() == ".dll" && item.Name.StartsWith("SnilAcademicDepartment"))
				.Select(item => Assembly.Load(AssemblyName.GetAssemblyName(item.FullName))).ToList();

			container.RegisterPackages(assemblies);

			RegisterAutoMapper(container, assemblies);
			// RegisterFluentValidation(container, assemblies);
		}

		/// <summary>
		///     Registers types of Fluent Validation service.
		/// </summary>
		/// <param name="container">
		///     The container for registration of dependencies.
		/// </param>
		/// <param name="assemblies">
		///     List of assemblies of application.
		/// </param>
		//private static void RegisterFluentValidation(Container container, IEnumerable<Assembly> assemblies)
		//{
		//    container.Register<IValidatorFactory, FluentValidationFactory>(Lifestyle.Singleton);
		//    container.Register(typeof(IValidator<>), assemblies, Lifestyle.Singleton);
		//}

		/// <summary>
		///     Registers types of Auto Mapper service.
		/// </summary>
		/// <param name="container">
		///     The container for registration of dependencies.
		/// </param>
		/// <param name="assemblies">
		///     List of assemblies of application.
		/// </param>
		private static void RegisterAutoMapper(Container container, IEnumerable<Assembly> assemblies)
		{
			container.Register(
				() =>
				{
					if (assemblies == null)
					{
						throw new ArgumentNullException(
							nameof(assemblies),
							"Collection of assemblies is null.");
					}

					var mapperConfigurationExpression = new MapperConfigurationExpression();
					mapperConfigurationExpression.ConstructServicesUsing(container.GetInstance);

					mapperConfigurationExpression.AddProfiles(assemblies);

					var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);
					mapperConfiguration.AssertConfigurationIsValid();

					IMapper mapper = new Mapper(mapperConfiguration, container.GetInstance);

					return mapper;
				},
				Lifestyle.Singleton);

			container.Register<ISNILConfigurationManager, SNILConfigurationManager>(Lifestyle.Singleton);
		}
	}
}
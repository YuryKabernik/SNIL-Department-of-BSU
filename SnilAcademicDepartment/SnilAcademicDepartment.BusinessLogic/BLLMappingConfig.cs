using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.DataAccess.Models;
using System.Linq;
using System.Net.Mail;

namespace SnilAcademicDepartment.BusinessLogic
{
	class BLLMappingConfig : Profile
	{
		public BLLMappingConfig()
		{
			// ------ EntityFramework mappings ------
			// Mapping preview objects.
			this.CreateMap<PreView, PreViewModel>()
				.ForMember(des => des.Title, opt => opt.MapFrom(s => s.Header))
				.ForMember(des => des.Description, opt => opt.MapFrom(s => s.ShortDescription))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image));

			// Mapping image objects.
			this.CreateMap<Image, ImageModel>()
				.ForMember(des => des.ImageName, opt => opt.MapFrom(s => s.ImageName))
				.ForMember(des => des.Content, opt => opt.MapFrom(s => s.Image1))
				.ForMember(des => des.ImageTypeExtenction, opt => opt.MapFrom(s => s.ImageTypeExtenction));

			// Mapping project objects.
			this.CreateMap<Project, ProjectModel>()
				.ForMember(des => des.ProjectId, opt => opt.MapFrom(s => s.CommonID))
				.ForMember(des => des.ProjectTitle, opt => opt.MapFrom(s => s.ProjectName))
				.ForMember(des => des.ProjectStatus, opt => opt.MapFrom(s => s.Status.ToString()))
				.ForMember(des => des.Localisation, opt => opt.MapFrom(s => s.Language.LanguageCode))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1))
				.ForMember(des => des.Document, opt => opt.MapFrom(s => s.Document.FileContent))
				.ForMember(des => des.CreationDate, opt => opt.MapFrom(s => s.CreationDate))
				.ForMember(des => des.Description, opt => opt.MapFrom(s => s.Description))
				.ForMember(des => des.ShortDescription, opt => opt.MapFrom(s => s.ShortDescription));

			//Mapping project preview objects.
			this.CreateMap<ProjectModel, ProjectPreview>()
				.ForMember(des => des.ProjectId, opt => opt.MapFrom(s => s.ProjectId))
				.ForMember(des => des.Title, opt => opt.MapFrom(s => s.ProjectTitle))
				.ForMember(des => des.ProjectStatus, opt => opt.MapFrom(s => s.ProjectStatus))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image))
				.ForMember(des => des.Description, opt => opt.MapFrom(s => s.ShortDescription));

			// Mapping EducationBlock objects.
			this.CreateMap<EducationBlock, EducationBlockModel>()
				.ForMember(des => des.Title, opt => opt.MapFrom(s => s.Name))
				.ForMember(des => des.Description, opt => opt.MapFrom(s => s.Description))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image1.Image1))
				.ForMember(des => des.Topics, opt => opt.MapFrom(s => s.EducationTopics.Select(p => p.TopicName)))
				.ForMember(des => des.ActionId, opt => opt.MapFrom(s => s.BlockId));

			// Mapping HallOfFame objects.
			this.CreateMap<HallOfFame, Leader>()
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.Person.PersonUniqueIdentifire))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Person.Image.Image1))
				.ForMember(des => des.FullName, opt => opt.MapFrom(s => s.Person.SecoundName + " " + s.Person.PersonName + " " + s.Person.FathersName));

			// Mapping Person type on Leader.
			this.CreateMap<Person, Leader>()
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.PersonUniqueIdentifire))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1))
				.ForMember(des => des.FullName, opt => opt.MapFrom(s => s.SecoundName + " " + s.PersonName + " " + s.FathersName))
				.ForAllOtherMembers(opt => opt.Ignore());

			// Mapping Document object.
			this.CreateMap<Document, DocumentModel>()
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.DocumentId))
				.ForMember(des => des.Name, opt => opt.MapFrom(s => s.DocumentName))
				.ForMember(des => des.Content, opt => opt.MapFrom(s => s.FileContent))
				.ForMember(des => des.CreatedOn, opt => opt.MapFrom(s => s.CreatedOn))
				.ForMember(des => des.FileType, opt => opt.MapFrom(s => s.FileTypeExtenction));

			// Mapping Lecture object LecturePreview.
			this.CreateMap<Lecture, LecturePreview>()
				.ForMember(des => des.Author, opt => opt.MapFrom(s => string.Concat(s.People.FirstOrDefault().PersonName, " ", s.People.FirstOrDefault().SecoundName)))
				.ForMember(des => des.LectureTitle, opt => opt.MapFrom(s => s.LectureName))
				.ForMember(des => des.Specialisation, opt => opt.MapFrom(s => s.Specialisation.SpecialisationName))
				.ForMember(des => des.DocumentId, opt => opt.MapFrom(s => s.DocumentId));

			// Mapping Seminar object SeminarPreview.
			this.CreateMap<Seminar, SeminarPreview>()
				.ForMember(des => des.Title, opt => opt.MapFrom(s => s.Title))
				.ForMember(des => des.SpeakersProfessionStatusAndFullNames, opt => opt
					.MapFrom(s => s.People.Select<Person, string>(j =>
					string.Concat(j.PersonName, j.SecoundName, $" ({j.ProfessionStatus.StatusNaming})"))))
				.ForMember(des => des.EventDate, opt => opt.MapFrom(s => s.EventDate))
				.ForMember(des => des.Topic, opt => opt.MapFrom(s => s.Topic1.TopicName))
				.ForMember(des => des.DocumentId, opt => opt.MapFrom(s => s.DoctId));

			this.CreateMap<IGrouping<int, Seminar>, IGrouping<int, SeminarPreview>>()
				.ForMember(des => des.Key, opt => opt.MapFrom(s => s.Key));

			this.CreateMap<ClientMail, MailMessage>()
				.ForMember(des => des.Body, opt => opt.MapFrom(s => s.Message))
				.ForMember(des => des.From, opt => opt.ResolveUsing(s => new MailAddress(s.Email)))
				.ForMember(des => des.Sender, opt => opt.ResolveUsing(s => new MailAddress(s.Email)))
				.ForMember(des => des.Subject, opt => opt.ResolveUsing(s => s.Subject))
				.ForMember(des => des.To, opt => opt.ResolveUsing(s => new MailAddressCollection()))
				.ForMember(des => des.CC, opt => opt.ResolveUsing(s => new MailAddressCollection()))
				.ForMember(des => des.Priority, opt => opt.ResolveUsing(s => MailPriority.Normal))
				.ForMember(des => des.IsBodyHtml, opt => opt.ResolveUsing(s => true))
				.ForAllOtherMembers(s => s.Ignore());

			this.CreateMap<Person, PersonVM>() // PersonVM
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.PersonUniqueIdentifire))
				.ForMember(des => des.PersonName, opt => opt.MapFrom(s => s.PersonName))
				.ForMember(des => des.SecoundName, opt => opt.MapFrom(s => s.SecoundName))
				.ForMember(des => des.FathersName, opt => opt.MapFrom(s => s.FathersName))
				.ForMember(des => des.ProfessionStatus, opt => opt.MapFrom(s => s.ProfessionStatus.StatusNaming))
				.ForMember(des => des.AcademicTitle, opt => opt.MapFrom(s => s.AcademicTitle.AcademicTitleNaming))
				.ForMember(des => des.Biography, opt => opt.MapFrom(s => s.Biography1.Description))
				.ForMember(des => des.Degree, opt => opt.MapFrom(s => s.Degree.DegreeNaming))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1))
				.ForMember(des => des.Lectures, opt => opt.MapFrom(s => s.Lectures.Select(o => o.LectureName)))
				.ForMember(des => des.Seminars, opt => opt.MapFrom(s => s.Seminars.Select(o => o.Title)))
				.ForMember(des => des.Projects, opt => opt.MapFrom(s => s.Projects.Select(o => o.ProjectName)));

			this.CreateMap<Person, Administrator>() // PersonVM
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.PersonUniqueIdentifire))
				.ForMember(des => des.PersonName, opt => opt.MapFrom(s => s.PersonName))
				.ForMember(des => des.SecoundName, opt => opt.MapFrom(s => s.SecoundName))
				.ForMember(des => des.FathersName, opt => opt.MapFrom(s => s.FathersName))
				.ForMember(des => des.ProfessionStatus, opt => opt.MapFrom(s => s.ProfessionStatus.StatusNaming))
				.ForMember(des => des.AcademicTitle, opt => opt.MapFrom(s => s.AcademicTitle.AcademicTitleNaming))
				.ForMember(des => des.Biography, opt => opt.MapFrom(s => s.Biography1.Description))
				.ForMember(des => des.Degree, opt => opt.MapFrom(s => s.Degree.DegreeNaming))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1));

			this.CreateMap<Person, Professor>() // Professor
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.PersonUniqueIdentifire))
				.ForMember(des => des.PersonName, opt => opt.MapFrom(s => s.PersonName))
				.ForMember(des => des.SecoundName, opt => opt.MapFrom(s => s.SecoundName))
				.ForMember(des => des.FathersName, opt => opt.MapFrom(s => s.FathersName))
				.ForMember(des => des.ProfessionStatus, opt => opt.MapFrom(s => s.ProfessionStatus.StatusNaming))
				.ForMember(des => des.AcademicTitle, opt => opt.MapFrom(s => s.AcademicTitle.AcademicTitleNaming))
				.ForMember(des => des.Biography, opt => opt.MapFrom(s => s.Biography1.Description))
				.ForMember(des => des.Degree, opt => opt.MapFrom(s => s.Degree.DegreeNaming))
				.ForMember(des => des.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress))
				.ForMember(des => des.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1))
				.ForMember(des => des.Lectures, opt => opt.MapFrom(s => s.Lectures.Select(o => o.LectureName)))
				.ForMember(des => des.Seminars, opt => opt.MapFrom(s => s.Seminars.Select(o => o.Title)))
				.ForMember(des => des.Projects, opt => opt.MapFrom(s => s.Projects.Select(o => o.ProjectName)));

			this.CreateMap<Person, MasterOfScience>() // MasterOfScience
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.PersonUniqueIdentifire))
				.ForMember(des => des.PersonName, opt => opt.MapFrom(s => s.PersonName))
				.ForMember(des => des.SecoundName, opt => opt.MapFrom(s => s.SecoundName))
				.ForMember(des => des.FathersName, opt => opt.MapFrom(s => s.FathersName))
				.ForMember(des => des.ProfessionStatus, opt => opt.MapFrom(s => s.ProfessionStatus.StatusNaming))
				.ForMember(des => des.AcademicTitle, opt => opt.MapFrom(s => s.AcademicTitle.AcademicTitleNaming))
				.ForMember(des => des.Biography, opt => opt.MapFrom(s => s.Biography1.Description))
				.ForMember(des => des.Degree, opt => opt.MapFrom(s => s.Degree.DegreeNaming))
				.ForMember(des => des.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress))
				.ForMember(des => des.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1))
				.ForMember(des => des.Seminars, opt => opt.MapFrom(s => s.Seminars.Select(o => o.Title)))
				.ForMember(des => des.Projects, opt => opt.MapFrom(s => s.Projects.Select(o => o.ProjectName)));

			this.CreateMap<Person, DoctorOfPhilosophy>() // MasterOfScience
				.ForMember(des => des.Id, opt => opt.MapFrom(s => s.PersonUniqueIdentifire))
				.ForMember(des => des.PersonName, opt => opt.MapFrom(s => s.PersonName))
				.ForMember(des => des.SecoundName, opt => opt.MapFrom(s => s.SecoundName))
				.ForMember(des => des.FathersName, opt => opt.MapFrom(s => s.FathersName))
				.ForMember(des => des.ProfessionStatus, opt => opt.MapFrom(s => s.ProfessionStatus.StatusNaming))
				.ForMember(des => des.AcademicTitle, opt => opt.MapFrom(s => s.AcademicTitle.AcademicTitleNaming))
				.ForMember(des => des.Biography, opt => opt.MapFrom(s => s.Biography1.Description))
				.ForMember(des => des.Degree, opt => opt.MapFrom(s => s.Degree.DegreeNaming))
				.ForMember(des => des.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress))
				.ForMember(des => des.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
				.ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1))
				.ForMember(des => des.Seminars, opt => opt.MapFrom(s => s.Seminars.Select(o => o.Title)))
				.ForMember(des => des.Projects, opt => opt.MapFrom(s => s.Projects.Select(o => o.ProjectName)));
		}
	}
}

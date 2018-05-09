using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class PreviewDBInit
    {
        private static string _description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. " +
                    "Sunt, consequatur delectus totam molestiae, in nam. Pariatur explicabo velit quas tempore rerum voluptas alias doloribus in repudiandae quos commodi asperiores quae esse iure cumque perspiciatis aperiam, expedita provident aspernatur nisi error molestias repellendus." +
                    " Magnam magni eveniet repudiandae officia fugit ullam facilis unde error earum voluptatum ducimus, ab nemo consequatur dignissimos tenetur perferendis inventore quaerat! Cupiditate a nesciunt animi excepturi temporibus ab, incidunt quidem! Dolor dolorum provident placeat eos ratione, inventore vitae accusantium quos, quo in quam quae officia voluptatum sit tempora doloribus, unde totam sunt enim iure dolorem. Ipsum, modi iusto." +
                    " Earum exercitationem aliquid asperiores eveniet tempora quidem, eius harum quasi consequuntur sunt error magni. Molestiae, voluptatem recusandae enim consequatur adipisci consequuntur corporis molestias nemo at doloribus, officiis accusamus. At voluptatem, rerum. Suscipit molestias autem ea ducimus aut reprehenderit." +
                    " Officiis dolor, esse repellat ut in officia asperiores ab dolores animi, eos tenetur cupiditate quis sapiente facere rem corporis adipisci quaerat, inventore sint ipsam nostrum impedit perspiciatis debitis maiores beatae! Molestiae vel eveniet, repudiandae ratione iure sunt asperiores enim dolore, at quisquam soluta! " +
                    "Magni deserunt tempore optio voluptate, aliquam? Nulla voluptates perspiciatis dicta iure libero quo, voluptas facere error ducimus sapiente rerum dolore. " +
                    "Natus, fugiat sunt architecto eos quas veniam aspernatur quia odit reprehenderit! Dolorum magni neque alias fugit cumque amet doloribus odit, iste nam laboriosam voluptatum aliquam quidem itaque dignissimos rerum eos eveniet ipsum? Nemo at nostrum necessitatibus, reiciendis inventore fugiat beatae, quis tenetur. Assumenda facere, quidem ullam corporis, eius quis similique magni blanditiis tempora, nemo tempore, ipsum. Molestias atque hic similique voluptatem modi mollitia ducimus deleniti laudantium tenetur." +
                    " Et quia dolorem, minima praesentium veniam doloribus, saepe dignissimos, beatae impedit voluptate est fugit! Magni earum odio, est quas amet debitis doloremque id repudiandae. Quo fuga ex ducimus, amet quaerat quis accusantium delectus ad laborum placeat minus quae maiores, esse totam! Officia nostrum sunt animi cumque autem quas facere accusantium incidunt veritatis unde repellat atque dolores quod blanditiis voluptate natus vitae temporibus, porro, aliquam mollitia." +
                    " Repellendus pariatur accusamus, molestiae aliquam dicta ipsum tempore omnis quibusdam, delectus iste fuga? Fugit debitis facilis assumenda dolorum laborum velit error nobis eveniet est, incidunt perferendis blanditiis sapiente possimus, asperiores temporibus expedita tempore ex saepe, ut. Alias quibusdam vel iusto expedita tempore reiciendis officia ducimus suscipit atque. Doloremque saepe tempore quae in labore quaerat cum animi, delectus magni, dolorum eveniet culpa. " +
                    "Quisquam dolores laboriosam eligendi ducimus, fugit, perspiciatis magnam sapiente ea aliquam nesciunt, assumenda voluptates ab qui sunt eum blanditiis tempore? Deserunt nulla, harum amet officiis modi explicabo. Molestiae a sunt, magni veniam nemo deleniti dolorum aliquid ea ab, asperiores tempora perferendis ducimus tenetur nulla! Consectetur numquam minus quaerat harum dolor voluptatibus labore odio voluptatem, distinctio ipsum nihil nulla explicabo ea animi amet quae nemo ad sequi, commodi porro. " +
                    "Corporis, quaerat labore non porro unde neque vitae nihil saepe qui sint cupiditate placeat, nam, vero laborum quisquam numquam sit aliquam dignissimos animi itaque. " +
                    "Sunt veniam natus reprehenderit doloremque velit, nemo, ut consequatur iure qui, laudantium alias facere.";

        private static string _shortDiscription = "Участники лаборатории, преподаватели и студенты кафедры. В данном разделе вы можете ознакомиться с преподавательским составом лаборатории и кафедры, а так же с самыми активными студентами и их достижениями в обучении и научной деятельности. Также вы можете ознакомиться с лучшими сотрудниками месяца.";

        public static void DBInit(
            SnilDBContext db,
            string header,
            string discriptionPrefix,
            PageType pageTypeName,
            Language language,
            byte[] imgPath,
            bool isShorted = false)
        {
            var preview = new PreView()
            {
                Header = header,
                ShortDescription = (isShorted ? discriptionPrefix + _shortDiscription : discriptionPrefix + _description),
                PageTypeName = pageTypeName,
                Language = language,
                Image = imgPath
            };

            db.PreViews.Add(preview);
            db.SaveChanges();
        }
    }
}

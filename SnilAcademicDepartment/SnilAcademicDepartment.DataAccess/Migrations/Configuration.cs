using System.Data.Entity.Migrations;
using System.Globalization;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using SnilAcademicDepartment.DataAccess.DBTypesInitialisation;
using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SnilDBContext>
    {
        
        private PageType[] _pageTypes;

        private Language[] _languages;

        private List<EducationBlock> _educationBlocks = new List<EducationBlock>();

        private Image _image;

        private byte[] _imgByte = File.ReadAllBytes(@"D:\GitHub_projects\SNIL\SNIL-Department-of-BSU\SnilAcademicDepartment\SnilAcademicDepartment.DataAccess\img\BSU3.jpg");

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SnilAcademicDepartment.DataAccess.SnilDBContext context)
        {
            using (var db = new SnilDBContext())
            {
                // Add page types.
                PageTypeDBInit.DBInit(db, out this._pageTypes);

                // Add languages.
                LanguageDBInit.DBInit(db, out this._languages);

                // Add image.
                ImageDBInit.DBInit(db, this._imgByte, out this._image);

                // Add Education blocks.
                EducationKeyAreaDBInit.DBInit(db, "Seminar", "RU", this._image, this._languages[1], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "ENSeminar", "EN", this._image, this._languages[0], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "DESeminar", "DE", this._image, this._languages[2], this._educationBlocks);

                EducationKeyAreaDBInit.DBInit(db, "Lection", "RU", this._image, this._languages[1], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "ENLection", "EN", this._image, this._languages[0], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "DELection", "DE", this._image, this._languages[2], this._educationBlocks);

                EducationKeyAreaDBInit.DBInit(db, "QuickLearning", "RU", this._image, this._languages[1], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "ENQuickLearning", "EN", this._image, this._languages[0], this._educationBlocks);
                EducationKeyAreaDBInit.DBInit(db, "DEQuickLearning", "DE", this._image, this._languages[2], this._educationBlocks);

                // Add EducationTopics.
                EducationTopicsSeminar(db);
                EducationLecture(db);
                EducationQuickLerning(db);

                // Init History page preview data.
                PreviewDBInit.DBInit(db, "History","RU", this._pageTypes[4], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Èñòîðèÿ", "EN", this._pageTypes[4], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ÈñòîðèÿDE", "DE", this._pageTypes[4], this._languages[2], this._imgByte);

                // Init People page preview data.
                PreviewDBInit.DBInit(db, "People", "RU", this._pageTypes[3], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Ïåðñîíàë", "EN", this._pageTypes[3], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ÏåðñîíàëDE", "DE", this._pageTypes[3], this._languages[2], this._imgByte);

                // Init Projects page preview data.
                PreviewDBInit.DBInit(db, "Projects", "RU", this._pageTypes[1], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Ïðîåêòû", "EN", this._pageTypes[1], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ÏðîåêòûDE", "DE", this._pageTypes[1], this._languages[2], this._imgByte);

                // Init Education page preview data.
                PreviewDBInit.DBInit(db, "Education", "RU", this._pageTypes[0], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Îáó÷åíèå", "EN", this._pageTypes[0], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "Îáó÷åíèåDE", "DE", this._pageTypes[0], this._languages[2], this._imgByte);

                // Init Home page preview data.
                PreviewDBInit.DBInit(db, "HomeProjects", "RUProjects", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìProjects", "ENProjects", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìDEProjects", "DEProjects", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "HomeEducation", "RUEducation", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìEducation", "ENEducation", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìDEEducation", "DEEducation", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "HomePeople", "RUPeople", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìPeople", "ENPeople", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìDEPeople", "DEPeople", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "HomeHistory", "RUHistory", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìHistory", "ENHistory", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìDEHistory", "DEHistory", this._pageTypes[2], this._languages[2], this._imgByte, true);

                PreviewDBInit.DBInit(db, "HomeProjects", "RUProjects", this._pageTypes[2], this._languages[1], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìProjects", "ENProjects", this._pageTypes[2], this._languages[0], this._imgByte, true);
                PreviewDBInit.DBInit(db, "ÄîìDEProjects", "DEProjects", this._pageTypes[2], this._languages[2], this._imgByte, true);
            }
        }

        private void EducationQuickLerning(SnilDBContext db)
        {
            EducationTopicDBInit.DBInit(db, "RUComputer Information Technologies", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUData Mining", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUQuantum Systems Modeling", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUDatabases", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUNeural Networks", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUProgramming of Microprocessor Systems", this._educationBlocks[6]);
            EducationTopicDBInit.DBInit(db, "RUObject-Oriented Technologies", this._educationBlocks[6]);
            //
            EducationTopicDBInit.DBInit(db, "ENComputer Information Technologies", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENData Mining", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENQuantum Systems Modeling", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENDatabases", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENNeural Networks", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENProgramming of Microprocessor Systems", this._educationBlocks[7]);
            EducationTopicDBInit.DBInit(db, "ENObject-Oriented Technologies", this._educationBlocks[7]);
            //
            EducationTopicDBInit.DBInit(db, "DEComputer Information Technologies", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEData Mining", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEQuantum Systems Modeling", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEDatabases", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DENeural Networks", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEProgramming of Microprocessor Systems", this._educationBlocks[8]);
            EducationTopicDBInit.DBInit(db, "DEObject-Oriented Technologies", this._educationBlocks[8]);
        }

        private void EducationLecture(SnilDBContext db)
        {
            EducationTopicDBInit.DBInit(db, "RUMathematical Modeling", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUSimulation and Statistical Modeling.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUTheory of Probability and Mathematical Statistics.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RURandom Processes.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUStochastic Systems.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUBasics of Systems Theory.", this._educationBlocks[3]);
            EducationTopicDBInit.DBInit(db, "RUInformation-Measuring Systems.", this._educationBlocks[3]);
            //
            EducationTopicDBInit.DBInit(db, "ENMathematical Modeling", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENSimulation and Statistical Modeling.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENTheory of Probability and Mathematical Statistics.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENRandom Processes.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENStochastic Systems.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENBasics of Systems Theory.", this._educationBlocks[4]);
            EducationTopicDBInit.DBInit(db, "ENInformation-Measuring Systems.", this._educationBlocks[4]);
            //
            EducationTopicDBInit.DBInit(db, "DEMathematical Modeling", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DESimulation and Statistical Modeling.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DETheory of Probability and Mathematical Statistics.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DERandom Processes.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DEStochastic Systems.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DEBasics of Systems Theory.", this._educationBlocks[5]);
            EducationTopicDBInit.DBInit(db, "DEInformation-Measuring Systems.", this._educationBlocks[5]);
        }

        private void EducationTopicsSeminar(SnilDBContext db)
        {
            EducationTopicDBInit.DBInit(db, "RUGene Expression of Secondary Messengers and Replicates", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUGenomic and Molecular Genetic Directions in the Area of Infectology", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUSoftware GeneExpressionAnalyser for analysis of DNA microarrays", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUAnalysis of DNA microarrays", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUDigital processing biology images", this._educationBlocks[0]);
            EducationTopicDBInit.DBInit(db, "RUSoftware CellDataMiner for Analysis of Luminescence Images of Cancer Cells", this._educationBlocks[0]);
            //
            EducationTopicDBInit.DBInit(db, "ENGene Expression of Secondary Messengers and Replicates", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENGenomic and Molecular Genetic Directions in the Area of Infectology", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENSoftware GeneExpressionAnalyser for analysis of DNA microarrays", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENAnalysis of DNA microarrays", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENDigital processing biology images", this._educationBlocks[1]);
            EducationTopicDBInit.DBInit(db, "ENSoftware CellDataMiner for Analysis of Luminescence Images of Cancer Cells", this._educationBlocks[1]);
            //
            EducationTopicDBInit.DBInit(db, "DEGene Expression of Secondary Messengers and Replicates", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DEGenomic and Molecular Genetic Directions in the Area of Infectology", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DESoftware GeneExpressionAnalyser for analysis of DNA microarrays", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DEAnalysis of DNA microarrays", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DEDigital processing biology images", this._educationBlocks[2]);
            EducationTopicDBInit.DBInit(db, "DESoftware CellDataMiner for Analysis of Luminescence Images of Cancer Cells", this._educationBlocks[2]);
        }
    }
}

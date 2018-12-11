using Common.Models;
using Converters;
using DAL.Repositories;

namespace CRM.BL.CrmServices
{
    public class LineServices
    {
        public LineServices()
        {
            Repo = new LineRepository();
            FromProgramToDb = new ConvertFromProgramToDb();
            FromDbToProgram = new ConvertFromDbToProgramModel();
        }

        private string lineCreated = "Line Created";
        private string lineFailed = "Line did not Created";
        private string lineExist = "Line already exist";
        private LineRepository Repo { get; set; }
        private ConvertFromProgramToDb FromProgramToDb { get; set; }
        private ConvertFromDbToProgramModel FromDbToProgram { get; set; }

        public CreateLineResult AddLine(LineModel line)
        {
            var lineEntity = FromProgramToDb.ConvertLine(line);
            CreateLineResult result = new CreateLineResult();

            if (Repo.IsLineExist(line.LineNumber))
            {
                result.IsCreated = false;
                result.Description = lineExist;
            }
            else
            {
                if (Repo.AddLine(lineEntity, lineEntity.UserId))
                {
                    result.Id = Repo.GetLine(line.LineNumber).LineId;
                    result.IsCreated = true;
                    result.Description = lineCreated;
                }
                else
                {
                    result.IsCreated = false;
                    result.Description = lineFailed;
                }
            }

            return result;
        }
    }
}

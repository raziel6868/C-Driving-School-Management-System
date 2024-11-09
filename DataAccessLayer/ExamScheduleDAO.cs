using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ExamScheduleDAO : SingletonBase<ExamScheduleDAO>
    {
        private List<ExamSchedule> list;

        public ExamScheduleDAO()
        {
            list = new List<ExamSchedule>();
            // Thêm dữ liệu mẫu
        }

        public List<ExamSchedule> GetAll() => list;

        public ExamSchedule GetByID(int id) => list.FirstOrDefault(x => x.ExamID == id);

        public void Add(ExamSchedule examSchedule)
        {
            list.Add(examSchedule);
        }

        public void Update(ExamSchedule examSchedule)
        {
            var index = list.FindIndex(x => x.ExamID == examSchedule.ExamID);
            if (index != -1)
            {
                list[index] = examSchedule;
            }
        }

        public void Delete(int id)
        {
            var examSchedule = GetByID(id);
            if (examSchedule != null)
            {
                list.Remove(examSchedule);
            }
        }
    }
}

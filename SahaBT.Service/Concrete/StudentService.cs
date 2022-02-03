using AutoMapper;
using SahaBT.Core.UnitOfWork.Abstract;
using SahaBT.Entities.Shared.ResultModel;
using SahaBT.Service.Abstract;
using SahaBT.Shared;
using SahaBT.Shared.Model;
using SahaBT.Shared.Model.ResultModel;
using SahaBT.Shared.Model.ViewModel;
using SahaBT.Shared.Pagination;
using System.Linq;
using System.Threading.Tasks;

namespace SahaBT.Service.Concrete
{
    public class StudentService : IStudentService
    {
        private int result = 0;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Create(StudentLessonAddModel model)
        {
            var student = await _unitOfWork.StudentRepository.Add(new Student { Name = model.StudentName, Age = model.StudentAge });
            if (await _unitOfWork.Complete() > 0)
            {
                if (_unitOfWork.StudentLessonRepository.IsThereCodeOfStudent(student.Id) == false)
                {
                    var lesson = await _unitOfWork.LessonRepository.Add(new Lesson { LessonCode = model.LessonCode });
                    await _unitOfWork.StudentLessonRepository.Add(new StudentLesson { Lesson = lesson, Student = student })
                        ;
                    await _unitOfWork.Complete();
                }
                return new ResponseModel
                {
                    Success = true,
                    Message = string.Empty,
                };
            }
            return new ResponseModel
            {
                Success = false,
                Message = "Öğrenci kaydedilirken hata oluştu"
            };
        }

        public async Task<ResponseModel> Update(StudentLessonUpdateModel model)
        {
            var response = await _unitOfWork.StudentRepository.Get(model.Id);
            var student = _mapper.Map<StudentLessonUpdateModel, Student>(model, response);
            _unitOfWork.StudentRepository.Update(student);
            result = await _unitOfWork.Complete();
            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    Message = string.Empty,
                };
            }
            return new ResponseModel
            {
                Success = false,
                Message = "Öğrenci güncellenirken hata oluştu"
            };
        }

        public async Task<ResponseModel> Delete(int studentId)
        {
            var student = await _unitOfWork.StudentRepository.Get(studentId);
            var ids = _unitOfWork.LessonRepository.GetLessonIds(student.Id);
             _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.Complete();
             _unitOfWork.LessonRepository.DeleteLessonIfNoStudent(ids);

            return new ResponseModel
            {
                Success = true,
                Message = string.Empty,
            };

        }

        public StudentsResponseModel GetStudents(PagingParameters model)
        {
            var students = _unitOfWork.StudentRepository.GetStudents(model);
            if (students.Students.Count()>0)
            {
                return new StudentsResponseModel
                {
                    Success = true,
                    Message = string.Empty,
                    Data = students
                };
            }

            return new StudentsResponseModel
            {
                Success = false,
                Message = "Öğrenci yok",
            };
        }

        public StudentsByLessonCodeResponseModel GetStudentsByLessonCode(string lessonCode)
        {
            var lesson = _unitOfWork.LessonRepository.GetLessonByCode(lessonCode);
            var students = _unitOfWork.StudentRepository.GetStudentsByLessonCode(lesson.Id);
            if (students.Count() > 0)
            {
                return new StudentsByLessonCodeResponseModel
                {
                    Success = true,
                    Message = string.Empty,
                    Data = students
                };
            }
            return new StudentsByLessonCodeResponseModel
            {
                Success = false,
                Message = "Öğrenci yok",
            };

        }

        public TotalStudentCountResponseModel GetStudentCount()
        {
            var response = _unitOfWork.StudentRepository.GetStudentCount();
            if (response.TotalStudentCount > 0)
            {
                return new TotalStudentCountResponseModel
                {
                    Success = true,
                    Message = string.Empty,
                    Data = response
                };
            }
            return new TotalStudentCountResponseModel
            {
                Success = false,
                Message = "Öğrenci yok",
            };
        }
    }
}

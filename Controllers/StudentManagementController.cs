using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentManagementController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        // private readonly IGradeRepository _gradeRepository;
        // private readonly IStudentAddressRepository _studentAddressRepository;
        private readonly IMapper _mapper;

        public StudentManagementController(IStudentRepository studentRepository, IMapper map) 
        {
             _studentRepository = studentRepository;
            // _gradeRepository = gradeRepository;
            // _studentAddressRepository =  studentAddressRepository;
            _mapper = map;
        }

        [HttpGet]
        [Route("GetStudents")]
        [Authorize(Roles = "reader")]
        public IActionResult GetAllStudents()
        {
            //Get all Students using Repositories
            var students =   _studentRepository.GetAll();
 
            // convert the Domain Models to DTos
            // var StudentsDTOs= new List<Models.DTOs.Student>();

            // foreach (var student in students)
            // {
            //     var StudentDTO = new Models.DTOs.Student()
            //     {
            //         IdOfStudent = student.StudentID,
            //         StudentName = student.StudentName,
            //         DateOfBirth = student.DateOfBirth,
            //         GradeId = student.GradeId,
            //         StudentAddressId = student.StudentAddressId
            //     };

            //     StudentsDTOs.Add(StudentDTO);
            // }

            // Convert Domain to DTO using AutoMapper
            var StudentsDTO = _mapper.Map<List<Models.DTOs.Student>>(students);
            return Ok(StudentsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetStudent")]
        [Authorize(Roles = "reader")]
        public IActionResult GetStudent([FromRoute]Guid id)
        {
            //using repository call the check the data exist in databse or not
             var student =  _studentRepository.Get(id);

             if(student == null)
             return NotFound($"The Student With Id = {id} ,cannot be found..");

            //  if the data exist the convert that  to DTO and send
            var studentDTO = _mapper.Map<Models.DTOs.Student>(student);

            return Ok(studentDTO);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        [Authorize(Roles = "writer")]
        public IActionResult DeleteStudent([FromRoute]Guid id)
        {
            // Check the student exist and delete
            var student =  _studentRepository.Delete(id);
            if(student == null)
             return NotFound($"The Student with Id ={id} , is already Deleted and don't exits..");

             //if found delete and send the deleted student data
            var studentDTO = _mapper.Map<Models.DTOs.Student>(student);

            return Ok(studentDTO);

        }

        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "writer")]
        public IActionResult AddStudent([FromBody]Models.DTOs.AddStudentRequest newStudent)
        {
            //Lets Validate model data coming from client
            // if(ValidateAddStudentRequest(newStudent))
            // {
            //     return BadRequest();
            // }

            //convert the DTO back to domain
            var student = _mapper.Map<Models.Domain.Student>(newStudent);

            //pass the domain to add in databse
            student = _studentRepository.Add(student);
            
            // Convert the domain back to DTO
            var studentDTO = _mapper.Map<Models.DTOs.Student>(student);

            // In post request we actually send the 201 created by CreatedAtAction().
            return CreatedAtAction(nameof(GetStudent),new {id = studentDTO.IdOfStudent},studentDTO);
        }

        [HttpPut]
        [Route("Update/{id:Guid}")]
        [Authorize(Roles = "writer")]
        public IActionResult UpdateStudent([FromRoute] Guid id,[FromBody]Models.DTOs.UpdateStudentRequest updateStudent)
        {
            // convert the DTO back the domain
            var student = _mapper.Map<Models.Domain.Student>(updateStudent);

            // check the id exist or not
            student = _studentRepository.Update(id,student);

            if(student == null)
            return NotFound($"The Student with Id ={id} cannot be upadate, because it is already Deleted or don't exits..");

            // convert back to DTO 
           var studentDTO = _mapper.Map<Models.DTOs.Student>(student);

            return Ok(studentDTO);   

        }

       
        // #region Private Methods

        // public bool ValidateAddStudentRequest(Models.DTOs.AddStudentRequest newStudent)
        // {
        //     DateTime datetime;
        //     if(newStudent == null){
        //       ModelState.AddModelError(nameof(Models.DTOs.AddStudentRequest),$"{nameof(Models.DTOs.AddStudentRequest)} cannot be Null...");
        //         return false;
        //     }

        //     if(string.IsNullOrWhiteSpace(newStudent.StudentName))
        //     {
        //          ModelState.AddModelError(nameof(Models.DTOs.AddStudentRequest.StudentName),$"{nameof(Models.DTOs.AddStudentRequest)} cannot be Null...");
        //     }

        //     if(! DateTime.TryParse(newStudent.DateOfBirth.ToString(),out datetime))
        //     {
        //          ModelState.AddModelError(nameof(Models.DTOs.AddStudentRequest.DateOfBirth),$"{nameof(Models.DTOs.AddStudentRequest.DateOfBirth)} cannot be valid format or date...");
        //     }

        //     var Grade = _gradeRepository.Get(newStudent.GradeId);
        //     if(Grade == null)
        //     {
        //         ModelState.AddModelError(nameof(Models.DTOs.AddStudentRequest.GradeId),$"{nameof(Models.DTOs.AddStudentRequest.GradeId)} cannot be EXIST in database please provide valid GradeId...");
        //     }
        //     var studentAddress = _studentAddressRepository.Get(newStudent.StudentAddressId);
        //     if(studentAddress == null)
        //     {
        //         ModelState.AddModelError(nameof(Models.DTOs.AddStudentRequest.StudentAddressId),$"{nameof(Models.DTOs.AddStudentRequest.StudentAddressId)} cannot be EXIST in database please provide valid GradeId...");
        //     }

        //     if(ModelState.ErrorCount > 0)
        //          return false;

        //     return true;
        // }

        // #endregion

    }

    
}
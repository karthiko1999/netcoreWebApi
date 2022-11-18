using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StudentAddressController : ControllerBase
    {
        private readonly IStudentAddressRepository _studentAddressRepository;
        private readonly IMapper _mapper;

        public StudentAddressController(IStudentAddressRepository studentAddressRepository,IMapper map) 
        {
            _studentAddressRepository = studentAddressRepository;
            _mapper = map;
        }

        [HttpGet]
        [Route("GetStudentAddresses")]
        public IActionResult GetAllStudentAddresses()
        {
            //Get all Students using Repositories
            var studentAddresses =   _studentAddressRepository.GetAll();


            // Convert Domain to DTO using AutoMapper
            var studentAddressesDTO = _mapper.Map<List<Models.DTOs.StudentAddress>>(studentAddresses);
            return Ok(studentAddressesDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetStudentAddress")]
        public IActionResult GetStudentAddress([FromRoute]Guid id)
        {
            //using repository call the check the data exist in databse or not
             var studentAddress =  _studentAddressRepository.Get(id);

             if(studentAddress == null)
             return NotFound($"The StudentAddress With Id = {id} ,cannot be found..");

            //  if the data exist the convert that  to DTO and send
            var studentAddressDTO = _mapper.Map<Models.DTOs.StudentAddress>(studentAddress);

            return Ok(studentAddressDTO);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult DeleteStudent([FromRoute]Guid id)
        {
            // Check the student exist and delete
            var studentAddress =  _studentAddressRepository.Delete(id);
            if(studentAddress == null)
             return NotFound($"The Student with Id ={id} , is already Deleted and don't exits..");

             //if found delete and send the deleted student data
            var studentAddressDTO = _mapper.Map<Models.DTOs.StudentAddress>(studentAddress);

            return Ok(studentAddressDTO);

        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddStudentAddress([FromBody]Models.DTOs.AddStudentAddressRequest newStudentAddress)
        {
            //convert the DTO back to domain
            var studentAddress = _mapper.Map<Models.Domain.StudentAddress>(newStudentAddress);

            //pass the domain to add in databse
            studentAddress = _studentAddressRepository.Add(studentAddress);
            
            // Convert the domain back to DTO
            var studentAddressDTO = _mapper.Map<Models.DTOs.StudentAddress>(studentAddress);

            // In post request we actually send the 201 created by CreatedAtAction().
            return CreatedAtAction(nameof(GetStudentAddress),new {id = studentAddressDTO.IdOfStudentAddress},studentAddressDTO);
        }

        [HttpPut]
        [Route("Update/{id:Guid}")]
        public IActionResult UpdateStudent([FromRoute] Guid id,[FromBody]Models.DTOs.UpdateStudentAddressRequest updateStudentAddress)
        {
            // convert the DTO back the domain
            var studentAddress = _mapper.Map<Models.Domain.StudentAddress>(updateStudentAddress);

            // check the id exist or not
            studentAddress = _studentAddressRepository.Update(id,studentAddress);

            if(studentAddress == null)
            return NotFound($"The StudentAddress with Id ={id} cannot be upadate, because it is already Deleted or don't exits..");

            // convert back to DTO 
            var studentAddressDTO = _mapper.Map<Models.DTOs.StudentAddress>(studentAddress);

            return Ok(studentAddressDTO);   

        }

    }
}
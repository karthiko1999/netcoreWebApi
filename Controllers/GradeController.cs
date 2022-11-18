using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeController(IGradeRepository gradeRepo,IMapper map) 
        {
            _gradeRepository = gradeRepo;
            _mapper = map;
        }

        [HttpGet]
        [Route("GetGrades")]
        [Authorize("reader")]
        [Authorize("writer")]
        public IActionResult GetAllGrades()
        {
            //Get all Students using Repositories
            var grades =   _gradeRepository.GetAll();
 
            // Convert Domain to DTO using AutoMapper
            var GradesDTO = _mapper.Map<List<Models.DTOs.Grade>>(grades);
            return Ok(GradesDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetGrade")]
        [Authorize("reader")]
        [Authorize("writer")]
        public IActionResult GetGrade([FromRoute]Guid id)
        {
            //using repository call the check the data exist in databse or not
             var grade =  _gradeRepository.Get(id);

             if(grade == null)
             return NotFound($"The Grade With Id = {id} ,cannot be found..");

            //  if the data exist the convert that  to DTO and send
            var gradeDTO = _mapper.Map<Models.DTOs.Grade>(grade);

            return Ok(gradeDTO);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        [Authorize("writer")]
        public IActionResult DeleteGrade([FromRoute]Guid id)
        {
            // Check the student exist and delete
            var grade =  _gradeRepository.Delete(id);
            if(grade == null)
             return NotFound($"The Grade with Id ={id} , is already Deleted and don't exits..");

             //if found delete and send the deleted student data
            var gradeDTO = _mapper.Map<Models.DTOs.Grade>(grade);

            return Ok(gradeDTO);

        }

        [HttpPost]
        [Route("Add")]
        [Authorize("writer")]
        public IActionResult AddGrade([FromBody]Models.DTOs.AddGradeRequest newGrade)
        {
            //convert the DTO back to domain
            var grade = _mapper.Map<Models.Domain.Grade>(newGrade);

            //pass the domain to add in databse
            grade = _gradeRepository.Add(grade);
            
            // Convert the domain back to DTO
            var gradeDTO = _mapper.Map<Models.DTOs.Grade>(grade);

            // In post request we actually send the 201 created by CreatedAtAction().
            return CreatedAtAction(nameof(GetGrade),new {id = gradeDTO.IdOfGrade},gradeDTO);
        }

        [HttpPut]
        [Route("Update/{id:Guid}")]
        [Authorize("writer")]
        public IActionResult UpdateGrade([FromRoute] Guid id,[FromBody]Models.DTOs.UpdateGradeRequest updateGrade)
        {
            // convert the DTO back the domain
            var grade = _mapper.Map<Models.Domain.Grade>(updateGrade);

            // check the id exist or not
            grade = _gradeRepository.Update(id,grade);

            if(grade == null)
            return NotFound($"The Grade with Id ={id} cannot be upadate, because it is already Deleted or don't exits..");

            // convert back to DTO 
            var studentDTO = _mapper.Map<Models.DTOs.Grade>(grade);

            return Ok(studentDTO);   

        }

    }
}
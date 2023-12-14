using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Models.ViewModels.Academic;
using Digital.Diary.Services.Abstractions.Academic;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Academic
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        private readonly IDesignationService _dService;
        private readonly IDepartmentService _deptService;
        private readonly IFacultyService _fService;

        public TeacherController(ITeacherService service, IDesignationService dService, IDepartmentService deptService, IFacultyService fService)
        {
            _service = service;
            _dService = dService;
            _deptService = deptService;
            _fService = fService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var entities = _service.GetAll();
            if (!entities.Any())
            {
                return BadRequest("No entity Found");
            }
            var entityListVMs = new List<TeacherVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;
                var deptName = _deptService.GetFirstOrDefault(x => x.Id == entity.DepartmentId).DeptName;
                var fName = _fService.GetFirstOrDefault(x => x.Id == entity.FacultyId).FacultyName;

                var entityVm = new TeacherVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    DesignationId = entity.DesignationId,
                    FacultyId = entity.FacultyId,
                    DepartmentId = entity.DepartmentId,
                    DesignationName = dName,
                    DepartmentName = deptName,
                    FacultyName = fName
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] TeacherVm createModel)
        {
            if (ModelState.IsValid)
            {
                Teacher finalEntity = createModel.ToModel();
                finalEntity.Id = Guid.NewGuid();
                var result = _service.Create(finalEntity);
                if (result.IsSucced)
                {
                    ModelState.Clear();
                    return Ok(result);
                }
                if (result.ErrorMessages.Any())
                {
                    foreach (var error in result.ErrorMessages)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return Ok(result);
                }
            }
            return Ok(createModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, TeacherVm editModel)
        {
            Teacher finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.Name = finalEntity.Name;
            existingEntity.Email = finalEntity.Email;
            existingEntity.PhoneNum = finalEntity.PhoneNum;
            existingEntity.ProfileImage = finalEntity.ProfileImage;
            existingEntity.DesignationId = finalEntity.DesignationId;
            existingEntity.FacultyId = finalEntity.FacultyId;
            existingEntity.DepartmentId = finalEntity.DepartmentId;
            var result = _service.Update(existingEntity);
            if (result.IsSucced)
            {
                ModelState.Clear();
                return Ok(result);
            }
            if (result.ErrorMessages.Any())
            {
                foreach (var error in result.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return Ok(finalEntity);
        }

        [HttpGet]
        [Route("Details/{id:Guid}")]
        public IActionResult Details(Guid id)
        {
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            var dName = _dService.GetFirstOrDefault(x => x.Id == existingEntity.DesignationId).DesignationName;
            var deptName = _deptService.GetFirstOrDefault(x => x.Id == existingEntity.DepartmentId).DeptName;
            var fName = _fService.GetFirstOrDefault(x => x.Id == existingEntity.FacultyId).FacultyName;
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new TeacherVm()
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                ProfileImage = existingEntity.ProfileImage,
                DesignationId = existingEntity.DesignationId,
                FacultyId = existingEntity.FacultyId,
                DepartmentId = existingEntity.DepartmentId,
                DesignationName = dName,
                DepartmentName = deptName,
                FacultyName = fName
            };
            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, TeacherVm deleteModel)
        {
            Teacher finalEntity = deleteModel.ToModel();

            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }

            var result = _service.Remove(existingEntity);
            if (result.IsSucced)
            {
                ModelState.Clear();
                return Ok(result);
            }
            if (result.ErrorMessages.Any())
            {
                foreach (var error in result.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return Ok();
        }
    }
}
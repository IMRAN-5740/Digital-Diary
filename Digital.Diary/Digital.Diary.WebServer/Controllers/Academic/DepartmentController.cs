using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Models.ViewModels.Academic;
using Digital.Diary.Services.Abstractions.Academic;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Academic
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly IFacultyService _fService;
        private readonly ITeacherService _tService;
        private readonly IDesignationService _dService;

        public DepartmentController(IDepartmentService service, IFacultyService fService, ITeacherService tService, IDesignationService dService)
        {
            _service = service;
            _fService = fService;
            _tService = tService;
            _dService = dService;
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
            var entityListVMs = new List<DepartmentVm>();

            foreach (var entity in entities)
            {
                var fName = _fService.GetFirstOrDefault(x => x.Id == entity.FacultyId);

                var entityVm = new DepartmentVm()
                {
                    Id = entity.Id,
                    DeptName = entity.DeptName,
                    FacultyId = entity.FacultyId,
                    FacultyName = fName.FacultyName,
                    Sequence = entity.Sequence,
                    ShortName = fName.ShortName,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetAllTeacherByDeptId(Guid id)
        {
            var entities = _tService.GetAll().Where(data => data.DepartmentId == id);
            if (!entities.Any())
            {
                return BadRequest("No entity Found");
            }
            var teacherListVm = new List<TeacherVm>();

            foreach (var entity in entities)
            {
                var dept = _service.GetFirstOrDefault(data => data.Id == entity.DepartmentId).DeptName;
                var degName = _dService.GetFirstOrDefault(data => data.Id == entity.DesignationId).DesignationName;
                var teacher = new TeacherVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    DepartmentName = dept,
                    DesignationName = degName,
                };
                teacherListVm.Add(teacher);
            }
            return Ok(teacherListVm);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] DepartmentVm createModel)
        {
            if (ModelState.IsValid)
            {
                Department finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, DepartmentVm editModel)
        {
            Department finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.DeptName = finalEntity.DeptName;
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
            var fName = _fService.GetFirstOrDefault(x => x.Id == existingEntity.FacultyId).FacultyName;

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new DepartmentVm()
            {
                Id = existingEntity.Id,
                DeptName = existingEntity.DeptName,
                FacultyId = existingEntity.FacultyId,
                FacultyName = fName,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, DepartmentVm deleteModel)
        {
            Department finalEntity = deleteModel.ToModel();

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
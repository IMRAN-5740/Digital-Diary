﻿using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Models.ViewModels.Administration.Offices;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Administration.Offices;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Administration.Offices
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _service;
        private readonly IOfficeEmployeeService _employeeService;
        private readonly IDesignationService _dService;

        public OfficeController(IOfficeService service, IDesignationService dService, IOfficeEmployeeService employeeService)
        {
            _service = service;
            _dService = dService;
            _employeeService = employeeService;
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
            var entityListVMs = new List<OfficeVm>();

            foreach (var entity in entities)
            {
                var entityVm = new OfficeVm()
                {
                    Id = entity.Id,
                    OfficeName = entity.OfficeName,
                    OfficeLevel = entity.OfficeLevel,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetAllEmployeeByOfficeId(Guid id)
        {
            var entities = _employeeService.GetAll().Where(data => data.OfficeId == id);
            if (!entities.Any())
            {
                return BadRequest("No entity Found");
            }
            var employeeListVm = new List<OfficeEmployeeVm>();

            foreach (var entity in entities)
            {
                var fact = _service.GetFirstOrDefault(data => data.Id == entity.OfficeId).OfficeName;
                var designation = _dService.GetFirstOrDefault(data => data.Id == entity.DesignationId).DesignationName;

                var dept = new OfficeEmployeeVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    OfficeId = entity.OfficeId,
                    OfficeName = fact,
                    DesignationName = designation
                };
                employeeListVm.Add(dept);
            }
            return Ok(employeeListVm);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] OfficeVm createModel)
        {
            if (ModelState.IsValid)
            {
                Office finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, OfficeVm editModel)
        {
            Office finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.OfficeName = finalEntity.OfficeName;

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
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new OfficeVm()
            {
                Id = existingEntity.Id,
                OfficeName = existingEntity.OfficeName
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, OfficeVm deleteModel)
        {
            Office finalEntity = deleteModel.ToModel();

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
                return Ok(result);
            }
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uesc.Api.DTOs.InputModel;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Business.IRepository;
using Uesc.Business.Services;
using Uesc.Business.Entities;

namespace Uesc.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;
        private readonly IMateriaRepository _materiaRepository;



        public  MateriaController(IMateriaService materiaService, IMateriaRepository materiaRepository)
        {
            _materiaService = materiaService;
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Materia>>> GetAll()
        {
            //return await  _materiaService.ListarMaterias();
            var materias = await _materiaRepository.GetAll();

            var materiasViewModel = materias.Select(a => new MateriaViewModel
            {
                Id = a.Id,
                Nome = a.Nome,
                CargaHoraria = a.CargaHoraria
            });

            return Ok(materiasViewModel);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<MateriaViewModel>> GetById(int id)
        {
           //return await _materiaService.BuscarMateriaPorId(id);
           var materia =  await _materiaRepository.GetById(id);

           var materiaViewModel = new MateriaViewModel
           {
               Id = materia.Id,
               Nome = materia.Nome,
               CargaHoraria = materia.CargaHoraria
           };

           return Ok(materiaViewModel);
        }

        [HttpPost]
        public async Task <ActionResult<MateriaViewModel>> Insert([FromBody] MateriaInputModel materia)
        {
            var materiaInserida =  await _materiaService.Insert(new Materia
            {
                Codigo = materia.Codigo,
                Nome = materia.Nome,
                CargaHoraria = materia.CargaHoraria,
            });

            var materiaViewModel = new MateriaViewModel
            {
                Id = materiaInserida.Id,
                Nome = materiaInserida.Nome,
                CargaHoraria = materiaInserida.CargaHoraria
            };


            return Ok(materiaViewModel);
        }

        [HttpPut("{id}")]
        public async Task <ActionResult<MateriaViewModel>> Update(int id, [FromBody] UpdateMateriaInputModel materia)
        {
            var alunoAtualizado = await _materiaService.Update(id,new Materia
            {
                Nome = materia.Nome,
                CargaHoraria = materia.CargaHoraria,
            });

            var materiaViewModel = new MateriaViewModel
            {
                Id = alunoAtualizado.Id,
                Nome = alunoAtualizado.Nome,
                CargaHoraria = alunoAtualizado.CargaHoraria
            };

            return Ok(materiaViewModel);
        }

        [HttpDelete("{id}")]
        public async Task <ActionResult<MateriaViewModel>> Delete(int id)
        {
            var materia = await _materiaService.Delete(id);

            var materiaViewModel = new MateriaViewModel
            {
                Id = materia.Id,
                Nome = materia.Nome,
                CargaHoraria = materia.CargaHoraria
            };
            return Ok(materiaViewModel);
        }
        

    }
}

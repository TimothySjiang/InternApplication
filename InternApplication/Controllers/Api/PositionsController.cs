using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using InternApplication.App_Start;
using InternApplication.Dtos;
using InternApplication.Models;

namespace InternApplication.Controllers.Api
{
    public class PositionsController : ApiController
    {
        private ApplicationDbContext _context;

        public PositionsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/positions
        [HttpGet]
        public IHttpActionResult Getpositions()
        {
            var positionDtos = _context.Positions
                .Include(c => c.Department)
                .ToList()
                .Select(Mapper.Map<Position, PositionDto>);

            return Ok(positionDtos);
        }

        // GET /api/positions/1
        [HttpGet]
        public IHttpActionResult Getposition(int id)
        {
            var position = _context.Positions.SingleOrDefault(c => c.Id == id);
            if (position == null)
                return NotFound();
            return Ok(Mapper.Map<Position, PositionDto>(position));
        }

        //Post /api/position/Create
        [HttpPost]
        public IHttpActionResult CreatePosition(PositionDto PositionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var position = Mapper.Map<PositionDto, Position>(PositionDto);
            _context.Positions.Add(position);
            _context.SaveChanges();
            PositionDto.Id = position.Id;
            return Created(new Uri(Request.RequestUri + "/" + position.Id), PositionDto);
        }

        [HttpPut]
        public IHttpActionResult UpdatePosition(int id, PositionDto positionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var positionInDb = _context.Positions.SingleOrDefault(c => c.Id == id);

            if (positionInDb == null)
                return NotFound();

            Mapper.Map(positionDto, positionInDb);

            _context.SaveChanges();

            return Ok();
        }

        
        [HttpDelete]
        public IHttpActionResult DeletePosition(int id)
        {
            var positionInDb = _context.Positions.SingleOrDefault(c => c.Id == id);

            if (positionInDb == null)
                return NotFound();

            _context.Positions.Remove(positionInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}

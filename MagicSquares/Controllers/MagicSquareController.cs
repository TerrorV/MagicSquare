using MagicSquares.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MagicSquares.Controllers
{
    public class MagicSquareController : ApiController
    {
        IMagicSquareService _squareService;
        public MagicSquareController(IMagicSquareService squareService)
        {
            _squareService = squareService;
        }

        [HttpGet]
        [Route("api/Square/{squareSize}/Constant")]
        public long GetSquareConstant(int squareSize)
        {
            return _squareService.GetSquareConstant(squareSize);
        }

        [HttpGet]
        [Route("api/Square/{squareSize}")]
        public int[,] GetSquare(int squareSize)
        {
                return _squareService.GetSquare(squareSize);
        }
    }
}

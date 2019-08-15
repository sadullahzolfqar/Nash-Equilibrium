using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nash_Dengesi_UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult computeNashEq(string _firstPlayerPayOff,string  _SecondPlayerPayOff,int _rows,int _columns)
        {

            string[] _FirstSplite = _firstPlayerPayOff.Split(',');
            string[] _SecondSplite = _SecondPlayerPayOff.Split(',');

            int[] _first=new int[_rows*_columns];
            int[] _Second = new int[_rows * _columns];

            int i = 0;
            int j = 0;
            foreach (string str in _FirstSplite)
            {
                _first[i] = Int32.Parse(str);
                i++;
            }

            foreach (string str in _SecondSplite)
            {
                _Second[j] = Int32.Parse(str);
                j++;
            }

            computeNashResult FinalResult = new computeNashResult();

            ComputeNash compute = new ComputeNash(_rows, _columns);


            compute.setPlayerData(_first, _Second);
            List<string> result = compute.Compute_Result();

            FinalResult.isMixed = false;
            
            if (result.Count < 1 && _rows==2 && _columns==2)
            {
                result= compute.comput_AandB_NashEquel(_first, _Second);
                FinalResult.isMixed = true;
            }
            FinalResult.Nashresult = result;
            FinalResult.fp_NashIndex = compute.f_NashIndexGet();
            FinalResult.Sp_NashIndex = compute.S_NashIndexGet();

            return Json(FinalResult, JsonRequestBehavior.AllowGet);
        }

    }
}
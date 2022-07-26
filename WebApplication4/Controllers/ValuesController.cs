using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static string sqlDataSource = "Data Source=DESKTOP-QIKIKNA\\MSSQLSERVER02;Initial Catalog=CustomerData; persist security info=True; Integrated Security = SSPI;";

        [HttpGet]
        public IEnumerable<string> Get()
        {

            string query = "select * from CustomerData";
            DataTable datatable = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand(query,myCon);
                SqlDataReader sqldr = cmd.ExecuteReader();               
                datatable.Load(sqldr);
            }

            string Jsonstring = JsonConvert.SerializeObject(datatable);
            return new string[] { Jsonstring };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            string query = "select * from CustomerData where CustomerId=" + id + " ";
            DataTable datatable = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand(query, myCon);
                SqlDataReader sqldr = cmd.ExecuteReader();
                datatable.Load(sqldr);
            }

            string Jsonstring = JsonConvert.SerializeObject(datatable);
            return Jsonstring;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(CustomerDatum value)
        {

            string query = "Insert into (customerName,phonenumber) customerData values( ('"+value.CustomerName+ "','" + value.PhoneNumber + "')"; //insert query 
            

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand(query, myCon);

                cmd.ExecuteNonQuery();
                 
            }


        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

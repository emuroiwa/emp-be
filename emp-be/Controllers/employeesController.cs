//------------------------------------------------------------------------------
// <inheritdoc>
//     Employee api for getting/finding/adding/deleting employee.
//
//     Ernest Muroiwa
// </inheritdoc>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using emp_be.Models;

namespace emp_be.Controllers
{
    public class employeesController : ApiController
    {
        private DBmodel db = new DBmodel();

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns>Ok with all employees.</returns>
        // GET: api/employees
        public IQueryable<employee> Getemployees()
        {
            return db.employees;
        }


        /// <summary>
        /// Update existing employee.
        /// </summary>
        /// <param name="id">Id of employee.</param>
        /// <param name="patch">JSON patch operations in body.</param>
        /// <returns>Ok with updated employee.</returns>
        // PUT: api/employees/5

        [ResponseType(typeof(void))]
        public IHttpActionResult Putemployee(int id, employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Add a employee.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Created status for successful post.</returns>
        // POST: api/employees

        [ResponseType(typeof(employee))]
        public IHttpActionResult Postemployee(employee employee)
        {

            db.employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        /// <summary>
        /// Deletes employee for given id.
        /// </summary>
        /// <param name="id">employee id.</param>
        /// <returns>No content status for successful deletion.</returns>
        // DELETE: api/employees/5

        [ResponseType(typeof(employee))]
        public IHttpActionResult Deleteemployee(int id)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}
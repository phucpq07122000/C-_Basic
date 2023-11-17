using homeWork_basic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.ISQLAdapter
{
    /// <summary>
    /// interface SQL Adapter
    /// </summary>
    public interface ISqlAdapter<T> where T : class, new()
    {
        /// <summary>
        /// ConnectionString Data
        /// </summary>
        public string ConnectionString { get; set; }
        
        /// <summary>
        ///  connect TableName
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// GetData 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> GetData() ; 

        /// <summary>
        /// Get data by ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        /// <summary>
        /// Add data 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="AddData"></param>
        /// <returns></returns>
        int Insert(T AddData);

        /// <summary>
        /// Update Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="UpdateData"></param>
        /// <returns></returns>
        int Update(T UpdateData);

        /// <summary>
        /// Delete Data by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns> 
        int Delete(Guid id); 

    }
}

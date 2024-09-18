using System;

namespace Service.Implement
{
    public class BaseService<T, TRepository> : IBaseService<T>
        where T : BaseModel
        where TRepository : IBaseRepository<T>
    {
        private readonly TRepository _repository;
        public BaseService(TRepository repository)
        {
            _repository = repository;
        }
        public virtual void Initialization(T model)
        {
            BaseInitialization(model);
        }
        public virtual void BaseInitialization(T model)
        {
        }
        public virtual T Save(T model)
        {
            if (model.ID > 0)
            {
                Update(model);
            }
            else
            {
                Add(model);
            }
            return model;
        }
        public virtual async Task<T> SaveAsync(T model)
        {
            if (model.ID > 0)
            {
                await UpdateAsync(model);
            }
            else
            {
                await AddAsync(model);
            }
            return model;
        }
        public virtual T Copy(T model)
        {
            int result = GlobalHelper.InitializationNumber;
            long IDOld = model.ID;
            model.ID = 0;
            _repository.Add(model);
            if (model.ID > 0)
            {
            }
            return model;
        }
        public virtual async Task<T> CopyAsync(T model)
        {
            int result = GlobalHelper.InitializationNumber;
            long IDOld = model.ID;
            model.ID = 0;
            await _repository.AddAsync(model);
            if (model.ID > 0)
            {
            }
            return model;
        }
        public virtual int Add(T model)
        {
            Initialization(model);
            int result = GlobalHelper.InitializationNumber;
            result = _repository.Add(model);
            return result;
        }
        public virtual async Task<int> AddAsync(T model)
        {
            Initialization(model);
            int result = GlobalHelper.InitializationNumber;
            result = await _repository.AddAsync(model);
            return result;
        }
        public virtual int Update(T model)
        {
            Initialization(model);
            return _repository.Update(model);
        }
        public virtual async Task<int> UpdateAsync(T model)
        {
            Initialization(model);
            return await _repository.UpdateAsync(model);
        }
        public virtual int Remove(long ID)
        {
            return _repository.Remove(ID);
        }
        public virtual async Task<int> RemoveAsync(long ID)
        {
            return await _repository.RemoveAsync(ID);
        }
        public virtual int AddRange(List<T> list)
        {
            return _repository.AddRange(list);
        }
        public virtual async Task<int> AddRangeAsync(List<T> list)
        {
            return await _repository.AddRangeAsync(list);
        }
        public virtual int UpdateRange(List<T> list)
        {
            return _repository.UpdateRange(list);
        }
        public virtual async Task<int> UpdateRangeAsync(List<T> list)
        {
            return await _repository.UpdateRangeAsync(list);
        }
        public virtual int RemoveRange(List<T> list)
        {
            return _repository.RemoveRange(list);
        }
        public virtual async Task<int> RemoveRangeAsync(List<T> list)
        {
            return await _repository.RemoveRangeAsync(list);
        }
        public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereCondition)
        {
            return _repository.GetByCondition(whereCondition);
        }
        public virtual T GetByID(long ID)
        {
            var result = _repository.GetByID(ID);
            return result;
        }
        public virtual async Task<T> GetByIDAsync(long ID)
        {
            var result = await _repository.GetByIDAsync(ID);
            return result;
        }
        public virtual T GetByName(string name)
        {
            var result = _repository.GetByName(name);
            return result;
        }
        public virtual async Task<T> GetByNameAsync(string name)
        {
            var result = await _repository.GetByNameAsync(name);
            return result;
        }
        public virtual T GetByCode(string code)
        {
            var result = _repository.GetByCode(code);
            return result;
        }
        public virtual async Task<T> GetByCodeAsync(string code)
        {
            var result = await _repository.GetByCodeAsync(code);
            return result;
        }
        public virtual List<T> GetAllToList()
        {
            return _repository.GetAllToList();
        }
        public virtual async Task<List<T>> GetAllToListAsync()
        {
            return await _repository.GetAllToListAsync();
        }
        public virtual List<T> GetByIDToList(long ID)
        {
            return _repository.GetByIDToList(ID);
        }
        public virtual async Task<List<T>> GetByIDToListAsync(long ID)
        {
            return await _repository.GetByIDToListAsync(ID);
        }
        public virtual List<T> GetByListIDToList(List<long> ListID)
        {
            return _repository.GetByListIDToList(ListID);
        }
        public virtual async Task<List<T>> GetByListIDToListAsync(List<long> ListID)
        {
            return await _repository.GetByListIDToListAsync(ListID);
        }
        public virtual List<T> GetByCodeToList(string Code)
        {
            return _repository.GetByCodeToList(Code);
        }
        public virtual async Task<List<T>> GetByCodeToListAsync(string Code)
        {
            return await _repository.GetByCodeToListAsync(Code);
        }
        public virtual List<T> GetByActiveToList(bool active)
        {
            return _repository.GetByActiveToList(active);
        }
        public virtual async Task<List<T>> GetByActiveToListAsync(bool active)
        {
            return await _repository.GetByActiveToListAsync(active);
        }
        public virtual List<T> GetByParentIDToList(long parentID)
        {
            return _repository.GetByParentIDToList(parentID);
        }
        public virtual async Task<List<T>> GetByParentIDToListAsync(long parentID)
        {
            return await _repository.GetByParentIDToListAsync(parentID);
        }
        public virtual List<T> GetByDanhMucUngDungIDToList(long DanhMucUngDungID)
        {
            return _repository.GetByDanhMucUngDungIDToList(DanhMucUngDungID);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDToListAsync(long DanhMucUngDungID)
        {
            return await _repository.GetByDanhMucUngDungIDToListAsync(DanhMucUngDungID);
        }
        public virtual List<T> GetByActiveAndSearchStringToList(bool Active, string searchString)
        {
            return _repository.GetByActiveAndSearchStringToList(Active, searchString);
        }
        public virtual async Task<List<T>> GetByActiveAndSearchStringToListAsync(bool Active, string searchString)
        {
            return await _repository.GetByActiveAndSearchStringToListAsync(Active, searchString);
        }
        public virtual List<T> GetByParentIDAndSearchStringToList(long parentID, string searchString)
        {
            return _repository.GetByParentIDAndSearchStringToList(parentID, searchString);
        }
        public virtual async Task<List<T>> GetByParentIDAndSearchStringToListAsync(long parentID, string searchString)
        {
            return await _repository.GetByParentIDAndSearchStringToListAsync(parentID, searchString);
        }
        public virtual List<T> GetByParentID_SearchStringToList(long parentID, string searchString)
        {
            List<T> result = new List<T>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = GetBySearchStringToList(searchString);
            }
            else
            {
                result = GetByParentIDToList(parentID);
            }
            return result;
        }
        public virtual async Task<List<T>> GetByParentID_SearchStringToListAsync(long parentID, string searchString)
        {
            List<T> result = new List<T>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToListAsync(searchString);
            }
            else
            {
                result = await GetByParentIDToListAsync(parentID);
            }
            return result;
        }
        public virtual List<T> GetByDanhMucUngDungIDAndSearchStringToList(long DanhMucUngDungID, string searchString)
        {
            return _repository.GetByDanhMucUngDungIDAndSearchStringToList(DanhMucUngDungID, searchString);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndSearchStringToListAsync(long DanhMucUngDungID, string searchString)
        {
            return await _repository.GetByDanhMucUngDungIDAndSearchStringToListAsync(DanhMucUngDungID, searchString);
        }
        public virtual List<T> GetByDanhMucUngDungIDAndActiveAndSearchStringToList(long DanhMucUngDungID, bool Active, string searchString)
        {
            return _repository.GetByDanhMucUngDungIDAndActiveAndSearchStringToList(DanhMucUngDungID, Active, searchString);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndActiveAndSearchStringToListAsync(long DanhMucUngDungID, bool Active, string searchString)
        {
            return await _repository.GetByDanhMucUngDungIDAndActiveAndSearchStringToListAsync(DanhMucUngDungID, Active, searchString);
        }
        public virtual List<T> GetByDanhMucUngDungID_SearchStringToList(long DanhMucUngDungID, string searchString)
        {
            List<T> result = new List<T>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = GetBySearchStringToList(searchString);
            }
            else
            {
                result = GetByDanhMucUngDungIDToList(DanhMucUngDungID);
            }
            return result;
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungID_SearchStringToListAsync(long DanhMucUngDungID, string searchString)
        {
            List<T> result = new List<T>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToListAsync(searchString);
            }
            else
            {
                result = await GetByDanhMucUngDungIDToListAsync(DanhMucUngDungID);
            }
            return result;
        }
        public virtual List<T> GetByParentIDAndActiveToList(long parentID, bool active)
        {
            return _repository.GetByParentIDAndActiveToList(parentID, active);
        }
        public virtual async Task<List<T>> GetByParentIDAndActiveToListAsync(long parentID, bool active)
        {
            return await _repository.GetByParentIDAndActiveToListAsync(parentID, active);
        }
        public virtual List<T> GetByDanhMucUngDungIDAndActiveToList(long DanhMucUngDungID, bool active)
        {
            return _repository.GetByDanhMucUngDungIDAndActiveToList(DanhMucUngDungID, active);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndActiveToListAsync(long DanhMucUngDungID, bool active)
        {
            return await _repository.GetByDanhMucUngDungIDAndActiveToListAsync(DanhMucUngDungID, active);
        }
        public virtual List<T> GetByParentIDAndCodeToList(long parentID, string code)
        {
            return _repository.GetByParentIDAndCodeToList(parentID, code);
        }
        public virtual async Task<List<T>> GetByParentIDAndCodeToListAsync(long parentID, string code)
        {
            return await _repository.GetByParentIDAndCodeToListAsync(parentID, code);
        }
        public virtual List<T> GetByDanhMucUngDungIDAndCodeToList(long DanhMucUngDungID, string code)
        {
            return _repository.GetByDanhMucUngDungIDAndCodeToList(DanhMucUngDungID, code);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndCodeToListAsync(long DanhMucUngDungID, string code)
        {
            return await _repository.GetByDanhMucUngDungIDAndCodeToListAsync(DanhMucUngDungID, code);
        }
        public virtual List<T> GetByParentIDAndCodeAndActiveToList(long parentID, string code, bool active)
        {
            return _repository.GetByParentIDAndCodeAndActiveToList(parentID, code, active);
        }
        public virtual async Task<List<T>> GetByParentIDAndCodeAndActiveToListAsync(long parentID, string code, bool active)
        {
            return await _repository.GetByParentIDAndCodeAndActiveToListAsync(parentID, code, active);
        }
        public virtual List<T> GetByDanhMucUngDungIDAndCodeAndActiveToList(long DanhMucUngDungID, string code, bool active)
        {
            return _repository.GetByDanhMucUngDungIDAndCodeAndActiveToList(DanhMucUngDungID, code, active);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndCodeAndActiveToListAsync(long DanhMucUngDungID, string code, bool active)
        {
            return await _repository.GetByDanhMucUngDungIDAndCodeAndActiveToListAsync(DanhMucUngDungID, code, active);
        }
        public virtual List<T> GetByLastUpdatedMembershipIDToList(long lastUpdatedMembershipID)
        {
            return _repository.GetByLastUpdatedMembershipIDToList(lastUpdatedMembershipID);
        }
        public virtual async Task<List<T>> GetByLastUpdatedMembershipIDToListAsync(long lastUpdatedMembershipID)
        {
            return await _repository.GetByLastUpdatedMembershipIDToListAsync(lastUpdatedMembershipID);
        }
        public virtual List<T> GetByLastUpdatedMembershipIDAndActiveToList(long lastUpdatedMembershipID, bool active)
        {
            return _repository.GetByLastUpdatedMembershipIDAndActiveToList(lastUpdatedMembershipID, active);
        }
        public virtual async Task<List<T>> GetByLastUpdatedMembershipIDAndActiveToListAsync(long lastUpdatedMembershipID, bool active)
        {
            return await _repository.GetByLastUpdatedMembershipIDAndActiveToListAsync(lastUpdatedMembershipID, active);
        }
        public virtual List<T> GetByParentIDAndLastUpdatedMembershipIDToList(long parentID, long lastUpdatedMembershipID)
        {
            return _repository.GetByParentIDAndLastUpdatedMembershipIDToList(parentID, lastUpdatedMembershipID);
        }
        public virtual async Task<List<T>> GetByParentIDAndLastUpdatedMembershipIDToListAsync(long parentID, long lastUpdatedMembershipID)
        {
            return await _repository.GetByParentIDAndLastUpdatedMembershipIDToListAsync(parentID, lastUpdatedMembershipID);
        }
        public virtual List<T> GetByParentIDAndDanhMucUngDungIDToList(long parentID, long DanhMucUngDungID)
        {
            return _repository.GetByParentIDAndDanhMucUngDungIDToList(parentID, DanhMucUngDungID);
        }
        public virtual async Task<List<T>> GetByParentIDAndDanhMucUngDungIDToListAsync(long parentID, long DanhMucUngDungID)
        {
            return await _repository.GetByParentIDAndDanhMucUngDungIDToListAsync(parentID, DanhMucUngDungID);
        }
        public virtual List<T> GetByParentIDAndLastUpdatedMembershipIDAndActiveToList(long parentID, long lastUpdatedMembershipID, bool active)
        {
            return _repository.GetByParentIDAndLastUpdatedMembershipIDAndActiveToList(parentID, lastUpdatedMembershipID, active);
        }
        public virtual async Task<List<T>> GetByParentIDAndLastUpdatedMembershipIDAndActiveToListAsync(long parentID, long lastUpdatedMembershipID, bool active)
        {
            return await _repository.GetByParentIDAndLastUpdatedMembershipIDAndActiveToListAsync(parentID, lastUpdatedMembershipID, active);
        }
        public virtual List<T> GetByParentIDAndDanhMucUngDungIDAndActiveToList(long parentID, long DanhMucUngDungID, bool active)
        {
            return _repository.GetByParentIDAndDanhMucUngDungIDAndActiveToList(parentID, DanhMucUngDungID, active);
        }
        public virtual async Task<List<T>> GetByParentIDAndDanhMucUngDungIDAndActiveToListAsync(long parentID, long DanhMucUngDungID, bool active)
        {
            return await _repository.GetByParentIDAndDanhMucUngDungIDAndActiveToListAsync(parentID, DanhMucUngDungID, active);
        }
        public virtual List<T> GetBySearchStringToList(string searchString)
        {
            return _repository.GetBySearchStringToList(searchString);
        }
        public virtual async Task<List<T>> GetBySearchStringToListAsync(string searchString)
        {
            return await _repository.GetBySearchStringToListAsync(searchString);
        }
        public virtual List<T> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            return _repository.GetByPageAndPageSizeToList(page, pageSize);
        }
        public virtual async Task<List<T>> GetByPageAndPageSizeToListAsync(int page, int pageSize)
        {
            return await _repository.GetByPageAndPageSizeToListAsync(page, pageSize);
        }
        public virtual List<T> GetByParentIDAndPageAndPageSizeToList(long ParentID, int page, int pageSize)
        {
            return _repository.GetByParentIDAndPageAndPageSizeToList(ParentID, page, pageSize);
        }
        public virtual async Task<List<T>> GetByParentIDAndPageAndPageSizeToListAsync(long ParentID, int page, int pageSize)
        {
            return await _repository.GetByParentIDAndPageAndPageSizeToListAsync(ParentID, page, pageSize);
        }
        public virtual List<T> GetByActiveAndPageAndPageSizeToList(bool Active, int page, int pageSize)
        {
            return _repository.GetByActiveAndPageAndPageSizeToList(Active, page, pageSize);
        }
        public virtual async Task<List<T>> GetByActiveAndPageAndPageSizeToListAsync(bool Active, int page, int pageSize)
        {
            return await _repository.GetByActiveAndPageAndPageSizeToListAsync(Active, page, pageSize);
        }
        public virtual List<T> GetByParentIDAndDanhMucUngDungIDAndPageAndPageSizeToList(long ParentID, long DanhMucUngDungID, int page, int pageSize)
        {
            return _repository.GetByParentIDAndDanhMucUngDungIDAndPageAndPageSizeToList(ParentID, DanhMucUngDungID, page, pageSize);
        }
        public virtual async Task<List<T>> GetByParentIDAndDanhMucUngDungIDAndPageAndPageSizeToListAsync(long ParentID, long DanhMucUngDungID, int page, int pageSize)
        {
            return await _repository.GetByParentIDAndDanhMucUngDungIDAndPageAndPageSizeToListAsync(ParentID, DanhMucUngDungID, page, pageSize);
        }
        public virtual List<T> GetByDanhMucUngDungIDAndPageAndPageSizeToList(long DanhMucUngDungID, int page, int pageSize)
        {
            return _repository.GetByDanhMucUngDungIDAndPageAndPageSizeToList(DanhMucUngDungID, page, pageSize);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndPageAndPageSizeToListAsync(long DanhMucUngDungID, int page, int pageSize)
        {
            return await _repository.GetByDanhMucUngDungIDAndPageAndPageSizeToListAsync(DanhMucUngDungID, page, pageSize);
        }
        public virtual List<T> GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToList(long DanhMucUngDungID, bool Active, int page, int pageSize)
        {
            return _repository.GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToList(DanhMucUngDungID, Active, page, pageSize);
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToListAsync(long DanhMucUngDungID, bool Active, int page, int pageSize)
        {
            return await _repository.GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToListAsync(DanhMucUngDungID, Active, page, pageSize);
        }
        public virtual List<T> GetByPageAndPageSizeAndIDToList(int page, int pageSize, long ID)
        {
            List<T> result = new List<T>();
            result.AddRange(_repository.GetByPageAndPageSizeToList(page, pageSize));
            if (ID > 0)
            {
                result.AddRange(GetByIDToList(ID));
            }
            return result;
        }
        public virtual async Task<List<T>> GetByPageAndPageSizeAndIDToListAsync(int page, int pageSize, long ID)
        {
            List<T> result = new List<T>();
            result.AddRange(await _repository.GetByPageAndPageSizeToListAsync(page, pageSize));
            if (ID > 0)
            {
                result.AddRange(await GetByIDToListAsync(ID));
            }
            return result;
        }
        public virtual List<T> GetByActiveAndPageAndPageSizeAndIDToList(bool Active, int page, int pageSize, long ID)
        {
            List<T> result = new List<T>();
            result.AddRange(_repository.GetByActiveAndPageAndPageSizeToList(Active, page, pageSize));
            if (ID > 0)
            {
                result.AddRange(GetByIDToList(ID));
            }
            return result;
        }
        public virtual async Task<List<T>> GetByActiveAndPageAndPageSizeAndIDToListAsync(bool Active, int page, int pageSize, long ID)
        {
            List<T> result = new List<T>();
            result.AddRange(await _repository.GetByActiveAndPageAndPageSizeToListAsync(Active, page, pageSize));
            if (ID > 0)
            {
                result.AddRange(await GetByIDToListAsync(ID));
            }
            return result;
        }
        public virtual string ExecuteNonQueryByStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            return _repository.ExecuteNonQueryByStoredProcedure(storedProcedureName, parameters);
        }
        public virtual async Task<string> ExecuteNonQueryByStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            return await _repository.ExecuteNonQueryByStoredProcedureAsync(storedProcedureName, parameters);
        }
        public virtual List<T> GetByStoredProcedureToList(string storedProcedureName, params SqlParameter[] parameters)
        {
            return _repository.GetByStoredProcedureToList(storedProcedureName, parameters);
        }
        public virtual async Task<List<T>> GetByStoredProcedureToListAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            return await _repository.GetByStoredProcedureToListAsync(storedProcedureName, parameters);
        }
        public virtual List<T> GetAllAndEmptyToList()
        {
            List<T> result = new List<T>();
            T empty = (T)Activator.CreateInstance(typeof(T));
            result.Add(empty);
            List<T> list = GetAllToList();
            if (list.Count > 0)
            {
                result.AddRange(list);
            }
            return result;
        }
        public virtual async Task<List<T>> GetAllAndEmptyToListAsync()
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetAllToListAsync();
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByParentIDAndEmptyToList(long parentID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByParentIDToList(parentID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByParentIDAndEmptyToListAsync(long parentID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByParentIDToListAsync(parentID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByCodeAndEmptyToList(string Code)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByCodeToList(Code);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByCodeAndEmptyToListAsync(string Code)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByCodeToListAsync(Code);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByParentID_SearchString_EmptyToList(long parentID, string SearchString)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByParentID_SearchStringToList(parentID, SearchString);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByParentID_SearchString_EmptyToListAsync(long parentID, string SearchString)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByParentID_SearchStringToListAsync(parentID, SearchString);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByDanhMucUngDungIDAndEmptyToList(long DanhMucUngDungID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByDanhMucUngDungIDToList(DanhMucUngDungID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndEmptyToListAsync(long DanhMucUngDungID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByDanhMucUngDungIDToListAsync(DanhMucUngDungID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByDanhMucUngDungID_SearchString_EmptyToList(long DanhMucUngDungID, string SearchString)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByDanhMucUngDungID_SearchStringToList(DanhMucUngDungID, SearchString);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungID_SearchString_EmptyToListAsync(long DanhMucUngDungID, string SearchString)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByDanhMucUngDungID_SearchStringToListAsync(DanhMucUngDungID, SearchString);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByParentIDAndDanhMucUngDungIDAndEmptyToList(long ParentID, long DanhMucUngDungID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByParentIDAndDanhMucUngDungIDToList(ParentID, DanhMucUngDungID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByParentIDAndDanhMucUngDungIDAndEmptyToListAsync(long ParentID, long DanhMucUngDungID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByParentIDAndDanhMucUngDungIDToListAsync(ParentID, DanhMucUngDungID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByParentIDAndActiveAndEmptyToList(long parentID, bool active)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByParentIDAndActiveToList(parentID, active);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByParentIDAndActiveAndEmptyToListAsync(long parentID, bool active)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByParentIDAndActiveToListAsync(parentID, active);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByLastUpdatedMembershipIDAndEmptyToList(long lastUpdatedMembershipID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetByLastUpdatedMembershipIDToList(lastUpdatedMembershipID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByLastUpdatedMembershipIDAndEmptyToListAsync(long lastUpdatedMembershipID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetByLastUpdatedMembershipIDToListAsync(lastUpdatedMembershipID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetBySearchStringAndEmptyToList(string searchString)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = GetBySearchStringToList(searchString);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetBySearchStringAndEmptyToListAsync(string searchString)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                result.Add(empty);
                List<T> list = await GetBySearchStringToListAsync(searchString);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public async Task<string> InsertItemsByDataTableAsync(DataTable table, string storedProcedureName)
        {
            string result = GlobalHelper.InitializationString;
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    int rowCount = GlobalHelper.RowCount;
                    int rowFrom = 0;
                    int rowTo = rowCount;
                    try
                    {
                        while (rowTo < table.Rows.Count)
                        {
                            DataTable tableSub = table.Clone();
                            tableSub.TableName = "tableSub";
                            tableSub.Clear();
                            for (int i = rowFrom; i < rowTo; i++)
                            {
                                DataRow newRow = tableSub.NewRow();
                                newRow.ItemArray = table.Rows[i].ItemArray;
                                tableSub.Rows.Add(newRow);
                            }
                            SqlParameter[] parameters =
                            {
                            new SqlParameter("@Table",tableSub),
                            };
                            result = await ExecuteNonQueryByStoredProcedureAsync(storedProcedureName, parameters);
                            if (result != "-1")
                            {
                                try
                                {
                                    foreach (DataRow row in tableSub.Rows)
                                    {
                                        for (int i = 0; i < 1; i++)
                                        {
                                            string row0 = (string)row[i];
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    result = ex.Message;
                                }
                            }
                            rowFrom = rowTo;
                            rowTo = rowTo + rowCount;
                        }
                        DataTable tableSub001 = table.Clone();
                        tableSub001.TableName = "tableSub";
                        tableSub001.Clear();
                        for (int i = rowFrom; i < table.Rows.Count; i++)
                        {
                            DataRow newRow = tableSub001.NewRow();
                            newRow.ItemArray = table.Rows[i].ItemArray;
                            tableSub001.Rows.Add(newRow);
                        }
                        SqlParameter[] parameters001 =
                        {
                            new SqlParameter("@Table",tableSub001),
                            };
                        result = await ExecuteNonQueryByStoredProcedureAsync(storedProcedureName, parameters001);
                        if (result != "-1")
                        {
                            try
                            {
                                foreach (DataRow row in tableSub001.Rows)
                                {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        string row0 = (string)row[i];
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                result = ex.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                }
            }
            return result;
        }
    }
}

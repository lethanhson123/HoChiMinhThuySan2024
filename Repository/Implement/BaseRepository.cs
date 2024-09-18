using System;

namespace Repository.Implement
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public virtual DbSet<T> DbSet()
        {
            return _context.Set<T>();
        }
        public virtual void Initialization(T model)
        {
            model.LastUpdatedDate = DateTime.Now;
            if (model.CreatedMembershipID == null)
            {
                model.CreatedMembershipID = model.LastUpdatedMembershipID;
            }
            if (model.CreatedDate == null)
            {
                model.CreatedDate = DateTime.Now;
            }
            if (model.Active == null)
            {
                model.Active = false;
            }
            if (model.RowVersion == null)
            {
                model.RowVersion = 1;
            }
            if (model.SortOrder == null || model.SortOrder == 0)
            {
                model.SortOrder = 10;
                try
                {
                    int maxSortOrder = GlobalHelper.InitializationNumber;
                    if (model.ParentID > 0)
                    {
                        maxSortOrder = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == model.ParentID).Select(x => x.SortOrder).Max().Value;
                    }
                    else
                    {
                        maxSortOrder = _context.Set<T>().AsNoTracking().Select(x => x.SortOrder).Max().Value;
                    }
                    model.SortOrder = maxSortOrder + 10;
                }
                catch (Exception ex)
                {
                    string mes = ex.Message;
                }
            }
            if (!string.IsNullOrEmpty(model.HTMLContent))
            {
                model.HTMLContent = System.Net.WebUtility.HtmlDecode(model.HTMLContent);
                model.HTMLContent = model.HTMLContent.Trim();
            }
            if (!string.IsNullOrEmpty(model.TypeName))
            {
                model.TypeName = model.TypeName.Trim();
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                model.Name = model.Name.Trim();
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                model.Code = model.Code.Trim();
            }
            if (!string.IsNullOrEmpty(model.Note))
            {
                model.Note = model.Note.Trim();
            }
            if (!string.IsNullOrEmpty(model.Display))
            {
                model.Display = model.Display.Trim();
            }
            if (!string.IsNullOrEmpty(model.FileName))
            {
                model.FileName = model.FileName.Trim();
            }
            if (!string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.Description.Trim();
            }
        }
        public virtual int Add(T model)
        {
            int result = 0;
            try
            {
                Initialization(model);
                _context.Set<T>().Add(model);
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual async Task<int> AddAsync(T model)
        {
            int result = 0;
            try
            {
                Initialization(model);
                _context.Set<T>().Add(model);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual int Update(T model)
        {
            int result = 0;
            try
            {
                var existModel = GetByID(model.ID);
                if (existModel != null)
                {
                    existModel = model;
                    Initialization(existModel);
                    existModel.RowVersion = existModel.RowVersion + 1;
                    _context.Set<T>().Update(existModel);
                }
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual async Task<int> UpdateAsync(T model)
        {
            int result = 0;
            try
            {
                var existModel = await GetByIDAsync(model.ID);
                if (existModel != null)
                {
                    existModel = model;
                    Initialization(existModel);
                    existModel.RowVersion = existModel.RowVersion + 1;
                    _context.Set<T>().Update(existModel);
                    result = await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual int Remove(long ID)
        {
            int result = 0;
            try
            {
                var existModel = GetByID(ID);
                if (existModel != null)
                {
                    _context.Set<T>().Remove(existModel);
                    result = _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual async Task<int> RemoveAsync(long ID)
        {
            int result = 0;
            try
            {
                var existModel = await GetByIDAsync(ID);
                if (existModel != null)
                {
                    _context.Set<T>().Remove(existModel);
                    result = await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual int AddRange(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().AddRange(list);
                result = _context.SaveChanges();
            }
            return result;
        }
        public virtual async Task<int> AddRangeAsync(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().AddRange(list);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public virtual int UpdateRange(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().UpdateRange(list);
                result = _context.SaveChanges();
            }
            return result;
        }
        public virtual async Task<int> UpdateRangeAsync(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().UpdateRange(list);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public virtual int RemoveRange(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().RemoveRange(list);
                result = _context.SaveChanges();
            }
            return result;
        }
        public virtual async Task<int> RemoveRangeAsync(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().RemoveRange(list);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereCondition)
        {
            var result = _context.Set<T>().AsNoTracking().Where(whereCondition);
            return result;
        }
        public virtual T GetByID(long ID)
        {
            var result = _context.Set<T>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = (T)Activator.CreateInstance(typeof(T));
            }
            return result;
        }
        public virtual async Task<T> GetByIDAsync(long ID)
        {
            var result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(model => model.ID == ID);
            if (result == null)
            {
                result = (T)Activator.CreateInstance(typeof(T));
            }
            return result;
        }
        public virtual T GetByName(string name)
        {
            var result = (T)Activator.CreateInstance(typeof(T));
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<T>().AsNoTracking().FirstOrDefault(model => model.Name.ToLower() == name.ToLower());
                if (result == null)
                {
                    result = (T)Activator.CreateInstance(typeof(T));
                }
            }
            return result;
        }
        public virtual async Task<T> GetByNameAsync(string name)
        {
            var result = (T)Activator.CreateInstance(typeof(T));
            if (!string.IsNullOrEmpty(name))
            {
                result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(model => model.Name.ToLower() == name.ToLower());
                if (result == null)
                {
                    result = (T)Activator.CreateInstance(typeof(T));
                }
            }
            return result;
        }
        public virtual T GetByCode(string code)
        {
            var result = _context.Set<T>().AsNoTracking().FirstOrDefault(model => model.Code == code);
            if (result == null)
            {
                result = (T)Activator.CreateInstance(typeof(T));
            }
            return result;
        }
        public virtual async Task<T> GetByCodeAsync(string code)
        {
            var result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(model => model.Code == code);
            if (result == null)
            {
                result = (T)Activator.CreateInstance(typeof(T));
            }
            return result;
        }
        public virtual List<T> GetAllToList()
        {
            var result = _context.Set<T>().AsNoTracking().ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetAllToListAsync()
        {
            var result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByIDToList(long ID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ID == ID).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByIDToListAsync(long ID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ID == ID).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByListIDToList(List<long> ListID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => ListID.Contains(item.ID)).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByListIDToListAsync(List<long> ListID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => ListID.Contains(item.ID)).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByCodeToList(string Code)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.Code == Code).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByCodeToListAsync(string Code)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.Code == Code).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByActiveToList(bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByActiveToListAsync(bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDToList(long parentID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDToListAsync(long parentID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByDanhMucUngDungIDToList(long DanhMucUngDungID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDToListAsync(long DanhMucUngDungID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByActiveAndSearchStringToList(bool Active, string searchString)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => (item.Active == Active) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByActiveAndSearchStringToListAsync(bool Active, string searchString)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => (item.Active == Active) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndSearchStringToList(long parentID, string searchString)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => (item.ParentID == parentID) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndSearchStringToListAsync(long parentID, string searchString)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => (item.ParentID == parentID) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByDanhMucUngDungIDAndSearchStringToList(long DanhMucUngDungID, string searchString)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => (item.DanhMucUngDungID == DanhMucUngDungID) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndSearchStringToListAsync(long DanhMucUngDungID, string searchString)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => (item.DanhMucUngDungID == DanhMucUngDungID) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByDanhMucUngDungIDAndActiveAndSearchStringToList(long DanhMucUngDungID, bool Active, string searchString)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => (item.DanhMucUngDungID == DanhMucUngDungID) && (item.Active == Active) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndActiveAndSearchStringToListAsync(long DanhMucUngDungID, bool Active, string searchString)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => (item.DanhMucUngDungID == DanhMucUngDungID) && (item.Active == Active) && (item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString))).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndActiveToList(long parentID, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndActiveToListAsync(long parentID, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByDanhMucUngDungIDAndActiveToList(long DanhMucUngDungID, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndActiveToListAsync(long DanhMucUngDungID, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndCodeToList(long parentID, string code)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Code == code).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndCodeToListAsync(long parentID, string code)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Code == code).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByDanhMucUngDungIDAndCodeToList(long DanhMucUngDungID, string code)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Code == code).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndCodeToListAsync(long DanhMucUngDungID, string code)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Code == code).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndCodeAndActiveToList(long parentID, string code, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Code == code && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndCodeAndActiveToListAsync(long parentID, string code, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Code == code && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByDanhMucUngDungIDAndCodeAndActiveToList(long DanhMucUngDungID, string code, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Code == code && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndCodeAndActiveToListAsync(long DanhMucUngDungID, string code, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Code == code && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByLastUpdatedMembershipIDToList(long lastUpdatedMembershipID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.LastUpdatedMembershipID == lastUpdatedMembershipID).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByLastUpdatedMembershipIDToListAsync(long lastUpdatedMembershipID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.LastUpdatedMembershipID == lastUpdatedMembershipID).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByLastUpdatedMembershipIDAndActiveToList(long lastUpdatedMembershipID, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.LastUpdatedMembershipID == lastUpdatedMembershipID && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByLastUpdatedMembershipIDAndActiveToListAsync(long lastUpdatedMembershipID, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.LastUpdatedMembershipID == lastUpdatedMembershipID && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndLastUpdatedMembershipIDToList(long parentID, long lastUpdatedMembershipID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.LastUpdatedMembershipID == lastUpdatedMembershipID).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndLastUpdatedMembershipIDToListAsync(long parentID, long lastUpdatedMembershipID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.LastUpdatedMembershipID == lastUpdatedMembershipID).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndDanhMucUngDungIDToList(long parentID, long DanhMucUngDungID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.DanhMucUngDungID == DanhMucUngDungID).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndDanhMucUngDungIDToListAsync(long parentID, long DanhMucUngDungID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.DanhMucUngDungID == DanhMucUngDungID).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndLastUpdatedMembershipIDAndActiveToList(long parentID, long lastUpdatedMembershipID, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.LastUpdatedMembershipID == lastUpdatedMembershipID && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndLastUpdatedMembershipIDAndActiveToListAsync(long parentID, long lastUpdatedMembershipID, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.LastUpdatedMembershipID == lastUpdatedMembershipID && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndDanhMucUngDungIDAndActiveToList(long parentID, long DanhMucUngDungID, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.DanhMucUngDungID == DanhMucUngDungID && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndDanhMucUngDungIDAndActiveToListAsync(long parentID, long DanhMucUngDungID, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.DanhMucUngDungID == DanhMucUngDungID && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetBySearchStringToList(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return _context.Set<T>().AsNoTracking().Where(item => item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString)).ToList();
            }
            else
            {
                return new List<T>();
            }
        }
        public virtual async Task<List<T>> GetBySearchStringToListAsync(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return await _context.Set<T>().AsNoTracking().Where(item => item.ID.ToString().Contains(searchString) || item.Name.Contains(searchString) || item.Code.Contains(searchString) || item.Display.Contains(searchString)).ToListAsync();
            }
            else
            {
                return new List<T>();
            }
        }
        public virtual List<T> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _context.Set<T>().AsNoTracking().Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public virtual async Task<List<T>> GetByPageAndPageSizeToListAsync(int page, int pageSize)
        {
            var result = await _context.Set<T>().AsNoTracking().Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
        public virtual List<T> GetByParentIDAndPageAndPageSizeToList(long ParentID, int page, int pageSize)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == ParentID).Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public virtual async Task<List<T>> GetByParentIDAndPageAndPageSizeToListAsync(long ParentID, int page, int pageSize)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == ParentID).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
        public virtual List<T> GetByActiveAndPageAndPageSizeToList(bool Active, int page, int pageSize)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.Active == Active).Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public virtual async Task<List<T>> GetByActiveAndPageAndPageSizeToListAsync(bool Active, int page, int pageSize)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.Active == Active).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
        public virtual List<T> GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToList(long DanhMucUngDungID, bool Active, int page, int pageSize)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Active == Active).Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndActiveAndPageAndPageSizeToListAsync(long DanhMucUngDungID, bool Active, int page, int pageSize)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID && item.Active == Active).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
        public virtual List<T> GetByParentIDAndDanhMucUngDungIDAndPageAndPageSizeToList(long ParentID, long DanhMucUngDungID, int page, int pageSize)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == ParentID && item.DanhMucUngDungID == DanhMucUngDungID).Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public virtual async Task<List<T>> GetByParentIDAndDanhMucUngDungIDAndPageAndPageSizeToListAsync(long ParentID, long DanhMucUngDungID, int page, int pageSize)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == ParentID && item.DanhMucUngDungID == DanhMucUngDungID).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
        public virtual List<T> GetByDanhMucUngDungIDAndPageAndPageSizeToList(long DanhMucUngDungID, int page, int pageSize)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID).Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public virtual async Task<List<T>> GetByDanhMucUngDungIDAndPageAndPageSizeToListAsync(long DanhMucUngDungID, int page, int pageSize)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.DanhMucUngDungID == DanhMucUngDungID).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
        public virtual string ExecuteNonQueryByStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            var result = GlobalHelper.InitializationString;
            try
            {
                result = SQLHelper.ExecuteNonQuery(_context.Database.GetConnectionString(), storedProcedureName, parameters);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        public virtual async Task<string> ExecuteNonQueryByStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            var result = GlobalHelper.InitializationString;
            try
            {
                result = await SQLHelper.ExecuteNonQueryAsync(_context.Database.GetConnectionString(), storedProcedureName, parameters);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByStoredProcedureToList(string storedProcedureName, params SqlParameter[] parameters)
        {
            List<T> result = new List<T>();
            try
            {
                DataTable dt = SQLHelper.FillDataTable(_context.Database.GetConnectionString(), storedProcedureName, parameters);
                result = SQLHelper.ToList<T>(dt);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByStoredProcedureToListAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            List<T> result = new List<T>();
            try
            {
                DataTable dt = await SQLHelper.FillDataTableAsync(_context.Database.GetConnectionString(), storedProcedureName, parameters);
                result = SQLHelper.ToList<T>(dt);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}

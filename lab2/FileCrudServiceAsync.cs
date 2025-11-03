using System;
}


public Task<T> ReadAsync(Guid id)
{
_store.TryGetValue(id, out var v);
return Task.FromResult(v);
}


public Task<IEnumerable<T>> ReadAllAsync()
{
return Task.FromResult(_store.Values.AsEnumerable());
}


public Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
{
if (page < 1) page = 1;
var skip = (page - 1) * amount;
var slice = _store.Values.Skip(skip).Take(amount);
return Task.FromResult(slice);
}


public Task<bool> UpdateAsync(T element)
{
_store[element.Id] = element;
return Task.FromResult(true);
}


public Task<bool> RemoveAsync(T element)
{
return Task.FromResult(_store.TryRemove(element.Id, out _));
}


public async Task<bool> SaveAsync()
{
await _fileLock.WaitAsync();
try
{
var list = _store.Values.ToList();
var tmp = _filePath + ".tmp";
await using (var fs = File.Create(tmp))
{
await JsonSerializer.SerializeAsync(fs, list, new JsonSerializerOptions { WriteIndented = true });
}
File.Move(tmp, _filePath, true);
return true;
}
catch
{
return false;
}
finally
{
_fileLock.Release();
}
}
}
}

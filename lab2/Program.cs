using System;


await Task.WhenAll(createTasks);


Console.WriteLine("All items created. Saving to file...");
// Demonstrate semaphore usage around save
await _sem.WaitAsync();
try
{
var saveOk = await service.SaveAsync();
Console.WriteLine($"Save finished: {saveOk}");
}
finally
{
_sem.Release();
}


// Demonstrate lock and AutoResetEvent in a small example
var thread = new Thread(() =>
{
lock (_lockObj)
{
Console.WriteLine("[Thread] entered lock, signalling main thread after short wait...");
Thread.Sleep(500);
_are.Set();
}
});
thread.Start();


Console.WriteLine("Main waiting for signal from worker thread (AutoResetEvent)...");
_are.WaitOne(); // wait for worker
Console.WriteLine("Signal received. Proceeding...");


// Analytics: min/max/avg for numeric fields
var all = (await service.ReadAllAsync()).ToList();
Console.WriteLine($"Total in store: {all.Count}");


if (all.Any())
{
var minHeight = all.Min(x => x.HeightCm);
var maxHeight = all.Max(x => x.HeightCm);
var avgHeight = all.Average(x => x.HeightCm);


var minLeaves = all.Min(x => x.LeafCount);
var maxLeaves = all.Max(x => x.LeafCount);
var avgLeaves = all.Average(x => x.LeafCount);


var minToxic = all.Min(x => x.ToxicLevel);
var maxToxic = all.Max(x => x.ToxicLevel);
var avgToxic = all.Average(x => x.ToxicLevel);


var report = $"Statistics for {all.Count} plants:\n"
+ $"HeightCm: min={minHeight}, max={maxHeight}, avg={avgHeight:F2}\n"
+ $"LeafCount: min={minLeaves}, max={maxLeaves}, avg={avgLeaves:F2}\n"
+ $"ToxicLevel: min={minToxic}, max={maxToxic}, avg={avgToxic:F2}\n";


Console.WriteLine(report);


// Save results to a text file (you can convert to PDF externally)
var resultPath = Path.Combine(Environment.CurrentDirectory, "lab2_results.txt");
await File.WriteAllTextAsync(resultPath, report);
Console.WriteLine($"Results written to {resultPath}");
}


Console.WriteLine("Done.");
}
}
}

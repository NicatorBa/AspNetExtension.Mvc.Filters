# AspNetExtension.Mvc.Filters

## Getting started

To use AspNetExtension.Mvc.Filters, you need to:

  - **Add the NuGet package to your `project.json`**:

```json
"dependencies": {
  "AspNetExtension.Mvc.Filters": "0.3.0"
}
```

  - **Add and configure the filter** in `Startup.ConfigureServices`:

```csharp
public void ConfigureService(IServiceCollection services){

    services.AddSingleton(new List<IClientErrorContract>
	{
	    new SampleContract()
	});

    services.AddMvc(options => {
	    options.Filter.Add(typeof(ClientErrorFilter));
	});
}
```

  - **Create your own Contract**:

```csharp
public class SampleContract : IClientErrorContract
{
    public async Task InvokeAsync(ClientErrorContext context, ContractExecutionDelegate next)
	{
	    // Your implementation
	}
}
```

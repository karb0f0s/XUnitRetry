# XUnitRetry

This repository is based on [giggio/xunit-retry](https://github.com/giggio/xunit-retry.git).
It introduces slightly modified `Retry` attribute that would allow some tests to be retried if they fail with specified exception.

## Examples

Test will be executed 3 times

```csharp
[Retry]
public void Assert_Fail_Test_And_Retry()
{
    Assert.Equal(1, 2);
}
```

Test will be executed 5 times

```csharp
[Retry(5, typeof(Exception))]
public void Exception_Fail_Test()
{
    throw new Exception();
}
```

Test will fail after first attempt

```csharp
[Retry(3, typeof(Exception))]
public void Assert_Fail_Test()
{
    Assert.Equal(1, 2);
}
```

## License

This software is open source, [licensed at MIT](https://github.com/karb0f0s/XUnitRetry/blob/master/LICENSE)

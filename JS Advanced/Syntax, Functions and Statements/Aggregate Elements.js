function aggregateElements(arr)
{
  function sums(arr)
  {
    let result = 0;
    for (var i = 0; i < arr.length; i++) {
      result += arr[i];
    }
    return result;
  }
  
  function sumsOneOverElement(arr)
  {
    let result = 0;
    for (var i = 0; i < arr.length; i++) {
      result += 1 / arr[i];
    }
    return result;
  }
  
  let sum = sums(arr);
  let average = sumsOneOverElement(arr);
  let s = "";
  for (var i = 0; i < arr.length; i++) {
    s += arr[i];
  }
  
  console.log(sum);
  console.log(average);
  console.log(s);
}

function aggregateElements1(arr)
{
  aggregate(arr, 0, (a, b) => a + b);
  aggregate(arr, 0, (a, b) => a + 1 / b);
  aggregate(arr, '', (a, b) => a + b);
  
  function aggregate(arr, initVal, func)
  {
    let val = initVal;
    for(let i = 0; i < arr.length; i++)
    {
      val = func(val, arr[i]);
    }
    
    console.log(val);
  }
}
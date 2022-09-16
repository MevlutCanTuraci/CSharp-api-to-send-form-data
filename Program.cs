try
{
    string URI = "your web api url";

    var _image = $@"C:/img.png";

    HttpClient httpClient = new HttpClient();
    MultipartFormDataContent form = new MultipartFormDataContent();

    form.Add(new StringContent("@turacican"), "userName");
    form.Add(new StringContent("developer"), "type");

    /*Example 1*/ 
    //(Recommended)

    //We stream files instead of keeping the entire file content in byte[] in memory
    var fileStream = new FileStream(_image, FileMode.Open); form.Add(new StreamContent(fileStream), "image" , "img");


    /*Example 2*/ 
    //(don't Recommended)

    //var file_bytes = File.ReadAllBytes(_image); // this.
    //here we are sending the variable where you keep the entire file contents as bytes[]. (its file_bytes variable)
    //form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "image", "img.png");
    
    /*Example 2*/

    HttpResponseMessage response = await httpClient.PostAsync(URI, form);

    response.EnsureSuccessStatusCode();
    httpClient.Dispose();

    string sd = response.Content.ReadAsStringAsync().Result;

    Console.WriteLine(sd);

}
catch (Exception ex)
{
    Console.WriteLine("Erorr : " + ex.Message);
}
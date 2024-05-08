@Imports RSATask.Domain.Models

<div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <div class="border rounded p-4">
                <h2 class="text-center mb-4">Weather Forecast</h2>
                <hr />
                <!-- Display Errors -->
                @If ViewData("ErrorMessage") IsNot Nothing Then
                    @<div class="alert alert-danger" role="alert">
                        @ViewData("ErrorMessage")
                    </div>
                End If

                <!-- Display Success Message -->
                @If ViewData("SuccessMessage") IsNot Nothing Then
                    @<div class="alert alert-success" role="alert">
                        @ViewData("SuccessMessage")
                    </div>
                End If

                @Using Html.BeginForm("Upload", "ForecastWeather", FormMethod.Post, New With {.enctype = "multipart/form-data"})
                    @Html.AntiForgeryToken()
                    @<div class="mb-3">
                        <label for="forecastFile" class="form-label">Upload a valid CSV file</label>
                        <input type="file" name="forecastFile" id="forecastFile" class="form-control">
                    </div>
                    @<div class="text-left">
                        <button class="btn btn-success" type="submit">Upload</button>
                        <a class="btn btn-danger" href="@Url.Action("List", "ForecastWeather")">View Previous Forecasts</a>
                    </div>
                End Using
            </div>
        </div>
    </div>
</div>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using BlazorWithMongo.Shared.Models;
using BlazorWithMongo.Client.Pages;

namespace BlazorWithMongo.Client.Pages
{
    public class HomeworkDataModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected List<Homework> hmwList;
        protected List<Ratings> ratingList = new List<Ratings>();

        protected Homework hmw = new Homework();
        protected string modalTitle { get; set; }
        protected Boolean isDelete = false;
        protected Boolean isAdd = false;

        protected string SearchString { get; set; }

        protected override async Task OnInitAsync()
        {
            await GetHomework();
            await GetRatings();
        }

        protected async Task GetHomework()
        {
            hmwList = await Http.GetJsonAsync<List<Homework>>("api/Homework/Index");
        }

        protected async Task GetRatings()
        {
            ratingList = await Http.GetJsonAsync<List<Ratings>>("api/Homework/GetRatings");
        }

        protected void AddHmw()
        {
            hmw = new Homework();
            this.modalTitle = "Add Homework";
            this.isAdd = true;
        }

        protected async Task EditHomework(string ID)
        {
            hmw = await Http.GetJsonAsync<Homework>("/api/Homework/Details/" + ID);
            this.modalTitle = "Edit Homework";
            this.isAdd = true;
        }

        protected async Task SaveHomework()
        {
            if (hmw.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Homework/Edit", hmw);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Homework/Create", hmw);

            }
            this.isAdd = false;
            await GetHomework();
        }

        protected async Task DeleteConfirm(string ID)
        {
            hmw = await Http.GetJsonAsync<Homework>("/api/Homework/Details/" + ID);
            this.isDelete = true;
        }

        protected async Task DeleteHomework(string ID)
        {
            await Http.DeleteAsync("api/Homework/Delete/" + ID);

            this.isDelete = false;
            await GetHomework();
        }
        protected void closeModal()
        {
            this.isAdd = false;
            this.isDelete = false;
        }
    }
}
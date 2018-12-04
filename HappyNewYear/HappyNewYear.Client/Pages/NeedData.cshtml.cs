using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using HappyNewYear.Shared.Models;

namespace HappyNewYear.Client.Pages
{
    public class NeedDataModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http1 { get; set; }

        protected List<Need> needList;
        protected List<Ratings> ratingList = new List<Ratings>();

        protected Need need = new Need();
        protected string modalTitle { get; set; }
        protected Boolean isDelete = false;
        protected Boolean isAdd = false;

        protected string SearchString { get; set; }

        protected override async Task OnInitAsync()
        {
            await GetNeed();
            await GetRatings();
        }

        protected async Task GetNeed()
        {
            needList = await Http1.GetJsonAsync<List<Need>>("api/Need/Index1");
        }

        protected async Task GetRatings()
        {
            ratingList = await Http1.GetJsonAsync<List<Ratings>>("api/Need/GetRatings");
        }

        protected void AddNeed()
        {
            need = new Need();
            this.modalTitle = "Add Need";
            this.isAdd = true;
        }

        protected async Task EditNeed(string ID)
        {
            need = await Http1.GetJsonAsync<Need>("/api/Need/Details/" + ID);
            this.modalTitle = "Edit Need";
            this.isAdd = true;
        }

        protected async Task SaveNeed()
        {
            if (need.Id != null)
            {
                await Http1.SendJsonAsync(HttpMethod.Put, "api/Need/Edit", need);
            }
            else
            {
                await Http1.SendJsonAsync(HttpMethod.Post, "/api/Need/Create", need);

            }
            this.isAdd = false;
            await GetNeed();
        }

        protected async Task DeleteConfirm(string ID)
        {
            need = await Http1.GetJsonAsync<Need>("/api/Need/Details/" + ID);
            this.isDelete = true;
        }

        protected async Task DeleteNeed(string ID)
        {
            await Http1.DeleteAsync("api/Need/Delete/" + ID);

            this.isDelete = false;
            await GetNeed();
        }
        protected void closeModal()
        {
            this.isAdd = false;
            this.isDelete = false;
        }
    }
}
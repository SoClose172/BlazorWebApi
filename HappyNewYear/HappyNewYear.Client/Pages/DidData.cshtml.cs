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
    public class DidDataModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected List<Did> didList;
        protected List<Ratings> ratingList = new List<Ratings>();

        protected Did did = new Did();
        protected string modalTitle { get; set; }
        protected Boolean isDelete = false;
        protected Boolean isAdd = false;

        protected string SearchString { get; set; }

        protected override async Task OnInitAsync()
        {
            await GetDid();
            await GetRatings();
        }

        protected async Task GetDid()
        {
            didList = await Http.GetJsonAsync<List<Did>>("api/Did/Index");
        }

        protected async Task GetRatings()
        {
            ratingList = await Http.GetJsonAsync<List<Ratings>>("api/Did/GetRatings");
        }

        protected void AddDid()
        {
            did = new Did();
            this.modalTitle = "Add Did";
            this.isAdd = true;
        }

        protected async Task EditDid(string ID)
        {
            did = await Http.GetJsonAsync<Did>("/api/Did/Details/" + ID);
            this.modalTitle = "Edit Did";
            this.isAdd = true;
        }

        protected async Task SaveDid()
        {
            if (did.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Did/Edit", did);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Did/Create", did);

            }
            this.isAdd = false;
            await GetDid();
        }

        protected async Task DeleteConfirm(string ID)
        {
            did = await Http.GetJsonAsync<Did>("/api/Did/Details/" + ID);
            this.isDelete = true;
        }

        protected async Task DeleteDid(string ID)
        {
            await Http.DeleteAsync("api/Did/Delete/" + ID);

            this.isDelete = false;
            await GetDid();
        }
        protected void closeModal()
        {
            this.isAdd = false;
            this.isDelete = false;
        }
    }
}
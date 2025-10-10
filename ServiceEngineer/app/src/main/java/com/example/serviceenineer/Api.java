package com.example.serviceenineer;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;
import retrofit2.http.Path;

public class Api {
    public static Users user;
    public static ArrayList<Users> users = new ArrayList<>();
    private static String urlApi = "http://10.0.2.2:44396/api/";
    public  static Retrofit retrofit = new Retrofit.Builder()
            .baseUrl(urlApi)
            .addConverterFactory(GsonConverterFactory.create())
            .build();
    public static interface ApiService{
        @GET("User/{email}/{password}")
        Call<Users> GetUser(@Path("email") String email,@Path("password") String password);
        @GET("Users/{id}/Notes")
        Call<List<Notes>> GetNotes(@Path("id") String id);
    }

    public static ApiService service = retrofit.create(Api.ApiService.class);
}

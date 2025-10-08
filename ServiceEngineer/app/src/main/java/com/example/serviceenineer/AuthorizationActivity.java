package com.example.serviceenineer;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AuthorizationActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_authorization);
    }
    public void Enter(View view){
        TextView Error = findViewById(R.id.TVTitle);
        EditText Email = findViewById(R.id.IEmail);
        EditText Password = findViewById(R.id.IPassword);
        Api.service.GetUser(Email.getText().toString(), Password.getText().toString()).enqueue(new Callback<Users>() {
            @Override
            public void onResponse(Call<Users> call, Response<Users> response) {
                if (response.isSuccessful()) {
                    Intent intent = new Intent(AuthorizationActivity.this, MainActivity.class);
                    startActivity(intent);
                }
                else
                    Toast.makeText(AuthorizationActivity.this, "faq", Toast.LENGTH_LONG).show();
            }

            @Override
            public void onFailure(Call<Users> call, Throwable t) {
                Error.setText(t.toString());
            }
        });
    }
    public void Click(View view){
        Toast.makeText(this, "Click", Toast.LENGTH_LONG).show();
    }
}
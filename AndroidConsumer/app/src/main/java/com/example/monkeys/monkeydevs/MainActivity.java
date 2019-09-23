package com.example.monkeys.monkeydevs;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import monkeyssdk.monkeyssdk.*;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        String monkey = new MonkeysSDK().getRandomMonkey();
        MonkeyIterator iterator = new MonkeysSDK().getMonkeyIterator();
    }
}

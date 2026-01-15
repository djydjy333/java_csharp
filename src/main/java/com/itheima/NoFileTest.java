package com.itheima;

import java.io.FileWriter;
import java.io.IOException;

public class NoFileTest {
    public static void main(String[] args) {
        try {
            // 创建一个FileWriter对象，指定文件名但不包括后缀
            FileWriter myWriter = new FileWriter("C:\\Users\\djy\\Desktop\\0325\\exampleFile");

            // 向文件写入内容
            myWriter.write("这里是一些文本内容。");

            // 关闭文件
            myWriter.close();

            System.out.println("成功写入到文件。");
        } catch (IOException e) {
            System.out.println("发生错误。");
            e.printStackTrace();
        }
    }
}

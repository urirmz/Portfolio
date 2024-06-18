Graphical user interfaces (GUIs)
When creating graphical user interfaces, we mostly make use of user-interface libraries that provide us with ready-made components, such as buttons and text areas. These user-interface libraries take care of the drawing the components for us, meaning that we don't have to draw every single component in our program, only add them to it.
A library called JavaFX is used to create graphical user interfaces.
We can create a simple window using JavaFX with the following program.
package application;
import javafx.application.Application;
import javafx.stage.Stage;
public class JavaFxApplication extends Application {
    @Override
    public void start(Stage window) {
        window.setTitle("Hello World!");
        window.show();
    }
    public static void main(String[] args) {
        launch(JavaFxApplication.class);
    }
}

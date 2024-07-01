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

Structure of a User Interface
Graphical user interfaces consist of three essential parts. The Stage object behaves as the program's window. A [Scene] (https://docs.oracle.com/javase/8/javafx/api/javafx/scene/Scene.html) is set for a Stage object that represents a scene within the window. The Scene object, on the other hand, contains an object responsible for arranging the components belonging to the scene (such as FlowPane), which contains the actual user interface components.
The program below creates an interface with a single button.
package application;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.FlowPane;
import javafx.stage.Stage;
public class JavaFxApplication extends Application {
    @Override
    public void start(Stage window) {
        Button button = new Button("This is a button");
        FlowPane componentGroup = new FlowPane();
        componentGroup.getChildren().add(button);
        Scene scene = new Scene(componentGroup);
        window.setScene(scene);
        window.show();
    }
    public static void main(String[] args) {
        launch(JavaFxApplication.class);
    }
}
UI components are added as "children" to the object responsible for setting them — FlowPane. This has to do with a JavaFx design decision, whereby each object responsible for UI components may contain other objects responsible for UI components as well as actual UI components. This enables GUIs where the layout of the UI components depends on their location on the user interface. For example, menu items located at the top of a UI are usually placed side by side, while list items are placed one below the other.
To briefly summarize, the UI structure is as follows. The window contains a Scene object. The Scene object contains the object responsible for the layout of the user-interface components. The object responsible for the component layout can contain both UI components and objects responsible for UI component layouts.

UI components and their layout
Text can be displayed using the Label class. The Label class provides a UI component for which text can be set, and offers methods for modifying the text it contains. The displayed text is either set in the constructor, or by using the setText method.
Label textComponent = new Label("Text element");
        FlowPane componentGroup = new FlowPane();
        componentGroup.getChildren().add(textComponent);
Buttons can be added using the Button class. Buttons are added the same way as labels.
Button buttonComponent = new Button("This is a button");
        FlowPane componentGroup = new FlowPane();
        componentGroup.getChildren().add(buttonComponent);
You can find a list of the available UI components on https://docs.oracle.com/javase/8/javafx/user-interface-tutorial/. The site also provides examples on how to use them.
With FlowPane, components that you add to the interface are placed side-by-side. If the size of Window is reduced so that the components no longer fit next to eahch other, the components will be automatically aligned.

BorderPane
The BorderPane class lets you lay out components in five different primary positions: top, right, bottom, left and center.
@Override
public void start(Stage window) {
BorderPane layout = new BorderPane();
layout.setTop(new Label("top"));
layout.setRight(new Label("right"));
layout.setBottom(new Label("bottom"));
layout.setLeft(new Label("left"));
layout.setCenter(new Label("center"));
        Scene view = new Scene(layout);
        window.setScene(view);
        window.show();
    }

HBox
HBox-class enables UI components to be laid out in a single horizontal row.
@Override
public void start(Stage window) {
HBox layout = new HBox();
    layout.getChildren().add(new Label("first"));
    layout.getChildren().add(new Label("second"));
    layout.getChildren().add(new Label("third"));
    Scene view = new Scene(layout);
    window.setScene(view);
    window.show();
}
The class VBox works in a similar way, but instead sets the components in a vertical column.

GridPane
The GridPane class can be used to lay the UI components in a grid. In the example below, we create a 3x3 row in which each cell contains a button.
@Override
public void start(Stage window) {
GridPane layout = new GridPane();
    for (int x = 1; x <= 3; x++) {
        for (int y = 1; y <= 3; y++) {
            layout.add(new Button("" + x + ", " + y), x, y);
        }
    }
    Scene view = new Scene(layout);
    window.setScene(view);
    window.show();
}

Multiple Layouts ons a Single Interface
Layout components can be combined. A typical setup involves using the BorderPane layout as the base with other layouts inside it. In the example below, the top of the BorderPane contains a HBox used for horizontal layout and a VBox used for vertical layouts. A text box has been placed placed in the center.
package application;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
public class JavaFxSovellus extends Application {
    @Override
    public void start(Stage window) {
        BorderPane layout = new BorderPane();
        HBox buttons = new HBox();
        buttons.setSpacing(10);
        buttons.getChildren().add(new Button("First"));
        buttons.getChildren().add(new Button("Second"));
        buttons.getChildren().add(new Button("Third"));
        VBox texts = new VBox();
        texts.setSpacing(10);
        texts.getChildren().add(new Label("First"));
        texts.getChildren().add(new Label("Second"));
        texts.getChildren().add(new Label("Third"));
        layout.setTop(buttons);
        layout.setLeft(texts);
        layout.setCenter(new TextArea(""));
        Scene view = new Scene(layout);
        window.setScene(view);
        window.show();
    }
    public static void main(String[] args) {
        launch(JavaFxSovellus.class);
    }
}
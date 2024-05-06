import React from 'react';
import './App.css';

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      quote: new Quote("", ""),
      color: ''
    }
    this.newQuoteAndColor = this.newQuoteAndColor.bind(this);
    this.appearTextAndAuthor = this.appearTextAndAuthor.bind(this);
  }

  componentDidMount() {    
    this.newQuoteAndColor();
    this.appearTextAndAuthor();
  }

  render() {
    const quoteAsWebQuery = "%22" + this.state.quote.phrase + "%22 \n-" +  this.state.quote.author;
    const twitterLink = `https://twitter.com/intent/post?text=${quoteAsWebQuery}`;
    const tumblerLink = `https://www.tumblr.com/widgets/share/tool?posttype=quotep&caption=${quoteAsWebQuery}&canonicalUrl=https%3A%2F%2Fwww.tumblr.com%2Fbuttons&shareSource=tumblr_share_button`;

    const transitionProperties = `all ${this.props.transitionTimeInSeconds + "s"} ease`;
    const fadeColorText = { color: this.state.color, transition: transitionProperties };
    const fadeColorBackground = { color: "white", backgroundColor: this.state.color, transition: transitionProperties };
    
    return (      
      <div id="page" className="container-fluid row align-items-center" style={fadeColorBackground}>
        <div id="quote-box" className="container-sm col-4 rounded-2">
          <p id="text" class="animated-appear" style={fadeColorText}>
            <i className="fa fa-quote-left quote-icon"></i>
            {this.state.quote.phrase}
            <i className="fa fa-quote-right quote-icon"></i>
          </p>
          <p id="author" class="animated-appear" style={fadeColorText}>- {this.state.quote.author}</p>
          <div className="buttons row gap-2">
            <a href={twitterLink} id="tweet-quote" target="_blank" rel="noreferrer" className="btn btn-default col-1 rounded-1" style={fadeColorBackground}>
              <i className="fa fa-twitter"></i>
            </a>
            <a href={tumblerLink}  id="tumblr-quote" target="_blank" rel="noreferrer" className="btn btn-default col-1 rounded-1" style={fadeColorBackground}>
              <i className="fa fa-tumblr"></i>
            </a>
            <button id="new-quote" className="btn btn-default col-auto ms-auto rounded-1" style={fadeColorBackground} onClick={this.newQuoteAndColor}>
              New quote
            </button>
          </div>          
        </div>
      </div>      
    );
  }

  newQuoteAndColor() {   
    const r = Math.floor(Math.random() * 255);
    const g = Math.floor(Math.random() * 255);
    const b = Math.floor(Math.random() * 255);
    const newColor = `rgb(${r}, ${g}, ${b})`;
  
    const quotes = [];
    quotes.push(new Quote("There are no traffic jams along the extra mile.", "Roger Staubach")); 
    quotes.push(new Quote("If the wind will not serve, take to the oars.", "Latin Proverb")); 
    quotes.push(new Quote("What’s money? A man is a success if he gets up in the morning and goes to bed at night and in between does what he wants to do.", "Bob Dylan")); 
    quotes.push(new Quote("Everything you’ve ever wanted is on the other side of fear.", "George Addair")); 
    quotes.push(new Quote("You can’t use up creativity. The more you use, the more you have.", "Maya Angelou"));
    quotes.push(new Quote("Remember no one can make you feel inferior without your consent.", "Eleanor Roosevelt"));
    quotes.push(new Quote("I have been impressed with the urgency of doing. Knowing is not enough; we must apply. Being willing is not enough; we must do.", "Leonardo da Vinci"));
    quotes.push(new Quote("The only way to do great work is to love what you do.", "Steve Jobs"));
    quotes.push(new Quote("You take your life in your own hands, and what happens? A terrible thing, no one to blame.", " Erica Jong"));
    quotes.push(new Quote("A person who never made a mistake never tried anything new.", "Albert Einstein"));
    quotes.push(new Quote("Every child is an artist. The problem is how to remain an artist once he grows up.", "Pablo Picasso"));
    quotes.push(new Quote("It’s not the years in your life that count. It’s the life in your years.", "Abraham Lincoln"));
    quotes.push(new Quote("Life shrinks or expands in proportion to one’s courage.", "Anais Nin"));
    quotes.push(new Quote("When one door of happiness closes, another opens, but often we look so long at the closed door that we do not see the one that has been opened for us.", "Helen Keller"));
    quotes.push(new Quote("The only person you are destined to become is the person you decide to be.", "Ralph Waldo Emerson"));
    quotes.push(new Quote("You can never cross the ocean until you have the courage to lose sight of the shore.", "Christopher Columbus"));
    quotes.push(new Quote("Remember that not getting what you want is sometimes a wonderful stroke of luck.", "Dalai Lama"));
    quotes.push(new Quote("You become what you believe.", "Oprah Winfrey"));
    quotes.push(new Quote("Start where you are. Use what you have. Do what you can.", "Arthur Ashe"));
    quotes.push(new Quote("Education costs money. But then so does ignorance.", "Sir Claus Moser"));
    const newQuoteIndex = Math.floor(Math.random() * (quotes.length - 1));     
    
    this.setState({quote: quotes[newQuoteIndex], color: newColor});
    this.appearTextAndAuthor();
  }

  appearTextAndAuthor() {
    let textAndAuthor = document.querySelectorAll(".animated-appear");
    
    textAndAuthor.forEach((element) => {
      element.style.animation = `appear ${this.props.transitionTimeInSeconds + "s"} ease`;      
    });

    let delay = this.props.transitionTimeInSeconds * 1000;

    setTimeout(() => {
      textAndAuthor.forEach((element) => {
        element.style.animation = "none";
      });
    }, delay);    
  }
}

class Quote {
  constructor(phrase, author) {
    this.phrase = phrase;
    this.author = author;
  }
}

export default App;

//Page Navigation
function showContent(id) {
    const contents = document.querySelectorAll('.content');
    contents.forEach(content => {
        if (content.id === id) {
            content.style.display = 'block';
        } else {
            content.style.display = 'none';
        }
    });
}

//Meditation audio 
const meditationAudio = new Audio('./sounds/Tranquil.mp3');

function playMeditationSound() {
    meditationAudio.play();
}

function pauseMeditationSound() {
    meditationAudio.pause();
}

//Breathing circle 
const container = document.getElementById('breathing-circle');
const text = document.getElementById('breathing-text');

const totalTime = 7500;
const breatheTime = (totalTime / 5) * 2;
const holdTime = totalTime / 5;

breathAnimation();

function breathAnimation() {
  text.innerText = 'Breathe In';
  container.className = 'breathing-container grow';

  setTimeout(() => {
    text.innerText = 'Hold';

    setTimeout(() => {
      text.innerText = 'Breathe Out';
      container.className = 'breathing-container shrink';
    }, holdTime);
  }, breatheTime);
}

setInterval(breathAnimation, totalTime);



//Journal feature
class Entry {
    constructor(id, title, text, savedAt) {
        this.id = id;
        this.title = title;
        this.text = text;
        this.savedAt = savedAt;
    }
}

class EntryManager {
    constructor() {
        this.entriesContainer = document.getElementById('entries-container');
    }

    loadEntries() {
        this.entriesContainer.innerHTML = '';

        const entries = JSON.parse(localStorage.getItem('entries')) || [];

        if (entries.length === 0) {
            this.entriesContainer.innerHTML = '<p>No entries yet.</p>';
            return;
        }

        entries.forEach(entry => {
            const entryDiv = this.createEntryElement(entry);
            this.entriesContainer.appendChild(entryDiv);
        });
    }

    createEntryElement(entry) {
        const entryDiv = document.createElement('div');
        entryDiv.id = `entry-${entry.id}`;
        entryDiv.className = 'entry';
        entryDiv.innerHTML = `
            <h3>${entry.title}</h3>
            <p class="entry-text">${entry.text}</p>
            <p>Time Saved: ${entry.savedAt}</p>
            <button class="delete-btn">Delete</button>
            <button class="toggle-btn">Hide</button>
            <button class="edit-btn">Edit</button>
        `;

        entryDiv.querySelector('.delete-btn').addEventListener('click', () => this.deleteEntry(entry.id));
        entryDiv.querySelector('.toggle-btn').addEventListener('click', () => this.toggleEntryText(entry.id));
        entryDiv.querySelector('.edit-btn').addEventListener('click', () => this.editEntry(entry.id));

        return entryDiv;
    }

    saveEntry(entryTitle, entryText) {
        if (entryText === '' || entryTitle === '') {
            alert('Please provide both title and entry before saving.');
            return;
        }

        const entryId = new Date().getTime();
        const savedAt = new Date().toLocaleString();
        const entry = new Entry(entryId, entryTitle, entryText, savedAt);

        this.saveEntryToLocalStorage(entry);
        this.clearInputFields();
        this.loadEntries();
    }

    saveEntryToLocalStorage(entry) {
        let entries = JSON.parse(localStorage.getItem('entries')) || [];
        const existingEntryIndex = entries.findIndex(e => e.id === entry.id);

        if (existingEntryIndex !== -1) {
            entries[existingEntryIndex] = entry;
        } else {
            entries.push(entry);
        }

        localStorage.setItem('entries', JSON.stringify(entries));
    }

    deleteEntry(entryId) {
        let entries = JSON.parse(localStorage.getItem('entries')) || [];
        entries = entries.filter(entry => entry.id !== entryId);
        localStorage.setItem('entries', JSON.stringify(entries));
        this.loadEntries();
    }

    toggleEntryText(entryId) {
        const entryDiv = document.getElementById(`entry-${entryId}`);
        const entryText = entryDiv.querySelector('.entry-text');
        entryText.classList.toggle('hidden');
    }

    editEntry(entryId) {
        const entry = JSON.parse(localStorage.getItem('entries')).find(e => e.id === entryId);
        if (entry) {
            document.getElementById('entry-title').value = entry.title;
            document.getElementById('journal-entry').value = entry.text;
        }
    }

    clearInputFields() {
        document.getElementById('entry-title').value = '';
        document.getElementById('journal-entry').value = '';
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const entryManager = new EntryManager();

    // Load existing entries from local storage
    entryManager.loadEntries();

    // Add event listener for the save button
    document.getElementById('save-btn').addEventListener('click', () => {
        const entryTitle = document.getElementById('entry-title').value.trim();
        const entryText = document.getElementById('journal-entry').value.trim();
        entryManager.saveEntry(entryTitle, entryText);
    });
});



//Cards Feature

(async () => {
    const fetchOptions = {
        method: 'GET',
        mode: 'cors',
    };

    try {
        const resp = await fetch('http://localhost:5090/api/wellness', fetchOptions);
        const data = await resp.json();
//Log data
        console.log('Fetched JSON data:', data);

        // Extract unique categories
        const categories = [...new Set(data.map(question => question.category))];

        // Create buttons for each category
        const categoriesDiv = document.getElementById('categories');
        const questionIndices = {};

        categories.forEach(category => {
            const button = document.createElement('button');
            button.innerText = category;
            button.addEventListener('click', () => showQuestions(category, data, questionIndices));
            categoriesDiv.appendChild(button);
        });
    } catch (error) {
        console.error('Error fetching data:', error);
    }
})();

// Function to show questions for a specific category
function showQuestions(category, data, questionIndices) {
    const currentIndex = questionIndices[category] || 0;

    // Filter questions for the selected category
    const filteredQuestions = data.filter(question => question.category === category);

    // Display questions as cards
    const questionsDiv = document.getElementById('questions');
    questionsDiv.innerHTML = '';

    // Calculate the next question index and update the index for the category
    const nextIndex = (currentIndex + 1) % filteredQuestions.length;
    questionIndices[category] = nextIndex;

    // Create a card element for the current question
    const questionCard = document.createElement('div');
    questionCard.classList.add('question-card');

    const questionElement = document.createElement('p');
    questionElement.innerText = filteredQuestions[currentIndex].questions;

    questionCard.appendChild(questionElement);
    questionsDiv.appendChild(questionCard);
}



import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Question } from 'src/app/_models/question';
import { Quiz } from 'src/app/_models/quiz';
import { Quiz_has_Question } from 'src/app/_models/quiz_has_question';
import { Solution } from 'src/app/_models/solution';

import { AuthService } from 'src/app/_services/auth.service';
import { QuestionsService } from 'src/app/_services/questions.service';
import { QuizService } from 'src/app/_services/quiz.service';
import { SharedService } from 'src/app/_services/shared.service';
import { SolutionsService } from 'src/app/_services/solutions.service';

export interface QuestionType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-creation-questions-quiz',
  templateUrl: './creation-questions-quiz.component.html',
  styleUrls: ['./creation-questions-quiz.component.css']
})
export class CreationQuestionsQuizComponent implements OnInit {

  questionnaireForm: FormGroup;
  quiz : Quiz ;
  index : number = 1;

  selectedOption = [];
  editMode = false;
  hiddenComment = new FormControl(false);

  constructor(
    private shared : SharedService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private questionsService: QuestionsService,
    private solutionsService: SolutionsService,
    private quizService: QuizService,
    private sharedService: SharedService,
  ) {
  }

  ngOnInit(): void {
    this.shared.quiz.subscribe((result)=> {
      this.quiz=result
    })
    this.initForm();
  }

  private initForm() {
    let surveyQuestions = new FormArray([]);
    this.questionnaireForm = new FormGroup({
      'surveyQuestions': surveyQuestions,
    });

    this.onAddQuestion(0);
  }

  onAddQuestion(index) {
    console.log(this.questionnaireForm);
    const surveyQuestionItem = new FormGroup({
      'questionTitle': new FormControl('', Validators.required),
      'questionComment' : new FormControl(''),
      'questionGroup': new FormGroup({})
    });
    (<FormArray>this.questionnaireForm.get('surveyQuestions')).push(surveyQuestionItem);
    this.addOptionControls(index);
    this.index = index + 1 ;
  }

  onRemoveQuestion(index) {
    this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionGroup = new FormGroup({});
    (<FormArray>this.questionnaireForm.get('surveyQuestions')).removeAt(index);
    this.selectedOption.splice(index,1)
    console.log(this.questionnaireForm);
  }

  addOptionControls(index) {

    let options = new FormArray([]);
    let showRemarksBox = new FormControl(false);
    (this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionGroup).addControl('options', options);
    (this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionGroup).addControl('showRemarksBox', showRemarksBox);
    this.clearFormArray((<FormArray>this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionGroup.controls.options));
    this.addOption(index);
    this.addOption(index);
  }

  private clearFormArray(formArray: FormArray) {
    while (formArray.length !== 0) {
      formArray.removeAt(0)
    }
  }

  addOption(index) {
    const optionGroup = new FormGroup({
      'optionText': new FormControl('', Validators.required),
      'isTrue' : new FormControl(''),
    });
    (<FormArray>this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionGroup.controls.options).push(optionGroup);
  }

  removeOption(questionIndex, itemIndex) {
    (<FormArray>this.questionnaireForm.controls.surveyQuestions['controls'][questionIndex].controls.questionGroup.controls.options).removeAt(itemIndex);
  }

  postSurvey() {

    let formData = this.questionnaireForm.value;

    console.log("formdata",formData);
    console.log();

    //Donnee du quizz en cour de creation
    let idQuizz : number  = this.quiz.idQuizz ;
    let name : string = this.quiz.name;
    let user_idUser : number = this.quiz.user_idUser;
    let theme_idTheme  : number = this.quiz.theme_idTheme;
    let code : string = this.quiz.code;
    let dateClosed : Date = this.quiz.dateClosed;
    let timer : number = this.quiz.timer;
    let level_idLevel : number = this.quiz.level_idLevel;
    let listquestions : Question[] = [];
    let surveyQuestions = formData.surveyQuestions;

    //on instancie ses données
    let survey = new Quiz(name, user_idUser, theme_idTheme, code, level_idLevel);
    console.log(survey);

    //pour chaque question...
    surveyQuestions.forEach((question) => {

      //... on instancie une nouvelle question
      let questionQuiz = new Question(question.questionTitle, 2, question.questionComment)

      //...on ajoute cette question dans la bdd
      this.questionsService
      .create(questionQuiz)
      .subscribe(callbackquestion =>{
         //...on intancie quizzHasQuestion qui lie une quesiton à son quiz
        let quizHasQuestion = new Quiz_has_Question(callbackquestion.idQuestion,this.quiz.idQuizz);
        //...on ajoute et lie cette question avec un quizz
        this.questionsService
        .createQuizHasQuestions(quizHasQuestion)
        .subscribe(
          {
            next:() =>{
              //... et pour chaque proposition de chaque question
              if (question.questionGroup.hasOwnProperty('options')) {
                question.questionGroup.options.forEach(option => {
                  let optionItem = {
                    "solution": option.optionText ,
                    "question_idQuestion": callbackquestion.idQuestion,
                    "isTrue": option.isTrue,
                  }

                  let SolutionIsTrue = false;
                  //if réponse vrai en set istrue a vrai
                  if(option.isTrue == true){
                    SolutionIsTrue = option.isTrue;
                  }

                //on instancie cette proposition
                let propositionQuestion = new Solution(option.optionText, callbackquestion.idQuestion, SolutionIsTrue)
                //...on ajoute cette proposition dans la bdd
                this.solutionsService
                .create(propositionQuestion)
                .subscribe(
                  {
                    next:() =>{
                      console.log("idQuizz", idQuizz);
                      console.log("thisQuizz.idQuizz", this.quiz.idQuizz);
                      this.continue(idQuizz);
                    }
                  }
                );

                });
              }
            }
          }
        );
        }
      );
     // survey.listquestions.push(questionItem)
    });

  }

  onSubmit() {
    this.postSurvey();
  }

  continue = (idQuiz :number) =>{
    this.quizService.getById(idQuiz).subscribe(
      (data) => {
          console.log("data",data);
          this.sharedService.UpdateQuiz(data)
          this.sharedService.UpdateCode(idQuiz)
          this.router.navigate(['/quiz-cree'], { relativeTo: this.route });
          })
  }

}

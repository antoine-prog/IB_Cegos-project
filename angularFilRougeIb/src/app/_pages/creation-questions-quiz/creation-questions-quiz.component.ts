import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Quiz } from 'src/app/_models/quiz';
import { Solution } from 'src/app/_models/solution';
import { AuthService } from 'src/app/_services/auth.service';
import { SharedService } from 'src/app/_services/shared.service';

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
    });
    (<FormArray>this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionGroup.controls.options).push(optionGroup);
  }

  removeOption(questionIndex, itemIndex) {
    (<FormArray>this.questionnaireForm.controls.surveyQuestions['controls'][questionIndex].controls.questionGroup.controls.options).removeAt(itemIndex);
  }

  postSurvey() {

    let formData = this.questionnaireForm.value;

    console.log(formData);
    console.log();

    let idQuizz = this.quiz.idQuizz ;
    let name = this.quiz.name;
    let user_idUser = this.quiz.user_idUser;
    let theme_idTheme = this.quiz.theme_idTheme;
    let code = this.quiz.code;
    let dateClosed = this.quiz.dateClosed;
    let timer = this.quiz.timer;
    let level_idLevel = this.quiz.level_idLevel;
    let listquestions = [];

    let surveyQuestions = formData.surveyQuestions;
    let optionArray = formData.surveyQuestions[0].questionGroup.options[0].optionText
    let survey = new Quiz( name, user_idUser, theme_idTheme, code, level_idLevel, listquestions, dateClosed, timer, idQuizz,);

    surveyQuestions.forEach((question, index, array) => {
      let questionItem = {
        "title": question.questionTitle,
        "level_idLevel": 2,
        "comment": question.commentaireText,
        "listSolution": [],
      }
      if (question.questionGroup.hasOwnProperty('options')) {
        question.questionGroup.options.forEach(option => {
          let optionItem: Solution = {

            "solution": option.optionText,
            "question_idQuestion": 0,
            "isTrue": false,
          }
          questionItem.listSolution.push(optionItem)
        });
      }
      survey.listquestions.push(questionItem)
    });
    console.log(survey);
    console.log('posting survey');
  }


  onSubmit() {
    this.postSurvey();
  }
}

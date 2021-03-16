import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

import { Survey, Option } from '../../_models/option';

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

  selectedOption = [];
  editMode = false;
  surveyTypes = [
    { id: 0, value: 'Training' },
    { id: 1, value: 'HR' }
  ];

  questions: QuestionType[] = [
    { value: 'Single choice', viewValue: 'Single choice' },
    { value: 'Multi choice', viewValue: 'Multi choice' },
    { value: 'Text', viewValue: 'Text' },
    { value: 'Rating', viewValue: 'Rating' }
  ];

  constructor(
    // private surveyService: SurveyService,
  ) {
  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    let surveyTitle = '';
    let surveyType = '';
    let surveyQuestions = new FormArray([]);

    this.questionnaireForm = new FormGroup({
      'surveyTitle': new FormControl(surveyTitle, [Validators.required]),
      'surveyType': new FormControl(surveyType, [Validators.required]),
      'surveyQuestions': surveyQuestions,
      'IsAnonymous': new FormControl(false, [Validators.required])
    });

    this.onAddQuestion();

  }

  onAddQuestion() {
    console.log(this.questionnaireForm);

    const surveyQuestionItem = new FormGroup({
      'questionTitle': new FormControl('', Validators.required),
      'questionType': new FormControl('', Validators.required),
      'questionGroup': new FormGroup({})
    });

    (<FormArray>this.questionnaireForm.get('surveyQuestions')).push(surveyQuestionItem);

  }

  onRemoveQuestion(index) {
    this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionGroup = new FormGroup({});
    this.questionnaireForm.controls.surveyQuestions['controls'][index].controls.questionType = new FormControl({});

    (<FormArray>this.questionnaireForm.get('surveyQuestions')).removeAt(index);
    this.selectedOption.splice(index,1)
    console.log(this.questionnaireForm);
  }

  onSeletQuestionType(questionType, index) {
    if (questionType === 'Single choice' || questionType === 'Multi choice') {
      this.addOptionControls(questionType, index)
    }
  }

  addOptionControls(questionType, index) {

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
    let ID = 0;
    let Type = formData.surveyType;
    let Title = formData.surveyTitle;
    let IsDeleted = false;
    let IsAnonymous = formData.IsAnonymous;
    //  let Question: Question[] = [];
    let Questions = [];

    let surveyQuestions = formData.surveyQuestions;
    let optionArray = formData.surveyQuestions[0].questionGroup.options[0].optionText
    let survey = new Survey(ID, Type, Title, IsDeleted, IsAnonymous, Questions);

    surveyQuestions.forEach((question, index, array) => {
      let questionItem = {
        'ID': 0,
        "Type": question.questionType,
        "Text": question.questionTitle,
        "options": [],
        "Required": false,
        "Remarks": "",
        "hasRemarks": false
      }
      if (question.questionGroup.hasOwnProperty('showRemarksBox')) {
        questionItem.hasRemarks = question.questionGroup.showRemarksBox;
      }
      if (question.questionGroup.hasOwnProperty('options')) {
        question.questionGroup.options.forEach(option => {
          let optionItem: Option = {
            "ID": 0,
            "OptionText": option.optionText,
            "OptionColor": "",
            "hasRemarks": false
          }
          questionItem.options.push(optionItem)
        });
      }
      survey.Question.push(questionItem)
    });
    console.log(survey);
    console.log('posting survey');
  }


  onSubmit() {

    this.postSurvey();

  }
}

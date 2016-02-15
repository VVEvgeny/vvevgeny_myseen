App.config(function ($stateProvider) {

    $stateProvider
        .state('books', {
            url: '/books/?:page&search',
            templateUrl: "Content/Angular/templates/main_pages/books.html",
            controller: 'BooksController',
            reloadOnSearch: false
        });
});

App.controller('BooksController', ['$scope', '$rootScope', '$state', '$stateParams', '$http', '$location', 'Constants',
  function ($scope, $rootScope, $state, $stateParams, $http, $location, constants) {

      //������ ��������, ��� �������� � �������
      var pageId = 2;
      //�������� �� ������ ��������
      $scope.pageCanAdd = true;
      //�������� �� ���� ������
      $scope.pageCanSearch = true;

      //�� ������ ������ ������, ����� ������� �� ��������, ��� ������ ������� ���������
      $rootScope.closeModals();

      //������� ���� ������ �� ���. ��������
      $scope.translation = {};
      //�������� �������� �� ��������� � �������
      $scope.prepared = {};
      //��������� ����������/�������������� ��������� ����� ���� ����� ������
      $scope.modal = {
          showName: true,
          showYear: true,
          showAuthors: true,
          showWhen: true,
          showGenre: true,
          showRating: true
      };
      //��������� �������
      $scope.modalShare = {};

      //��� ��������� ������� ������
      function fillPrepared(page) {
          $scope.prepared = page;
          $scope.prepared.loaded = true;
      }
      //������� ������� � ���������
      function fillTranslation(page) {
          $scope.translation = page;
          $scope.translation.loaded = true;
      }
      //�������� ������
      function fillScope(page) {
          $scope.data = page.Data;
          $scope.pages = page.Pages;
      };
      function getMainPage() {
          $rootScope.GetPage(constants.Pages.Main, $http, fillScope, { pageId: pageId, page: ($stateParams ? $stateParams.page : null), search: ($stateParams ? $stateParams.search : null) });
      };

      //����� 3 ������� �� ������, ����� ����� ������ ������� �� ����� ������ � �� ����������/���������
      $rootScope.GetPage(constants.Pages.Prepared, $http, fillPrepared, { pageId: pageId });
      $rootScope.GetPage(constants.Pages.Translation, $http, fillTranslation, { pageId: pageId });
      getMainPage();

      ///////////////////////////////////////////////////////////////////////
      ///////////////////////////////////////////////////////////////////////           �����
      ///////////////////////////////////////////////////////////////////////
      $scope.quickSearch = {};
      $scope.quickSearch.text = $stateParams ? $stateParams.search : null;
      $scope.searchButtonClick = function () {
          $location.search('search', $scope.quickSearch.text !== '' ? $scope.quickSearch.text : null);
          $location.search('page', null);//� ������ �������� ����� �����
          if ($stateParams) $stateParams.page = null;
          if ($stateParams) $stateParams.search = $scope.quickSearch.text !== '' ? $scope.quickSearch.text : null;
          getMainPage();
      };
      ///////////////////////////////////////////////////////////////////////
      ///////////////////////////////////////////////////////////////////////           ���������
      ///////////////////////////////////////////////////////////////////////
      //�� ��������� �������� �� ����������, ��� ������������� ����������, � ��� � ���� � ���������� ��� ���������� ����� reloadOnSearch: false      
      $scope.pagination = {};
      $scope.pagination.goToPage = function (page) {
          $location.search('page', page > 1 ? page : null);
          if ($stateParams) $stateParams.page = page > 1 ? page : null;
          getMainPage();
      }
      ///////////////////////////////////////////////////////////////////////
      ///////////////////////////////////////////////////////////////////////           ��������� ���������� / ��������������
      ///////////////////////////////////////////////////////////////////////
      //����� ��������� ��������/�������������
      //������� ������ ��� ���������� ����� ������ � ��������� ���������
      $scope.addModalOpen = function () {
          $scope.modal.title = $scope.translation.TitleAdd;
          $scope.modal.name = '';
          $scope.modal.year = $scope.prepared.Year;
          $scope.modal.authors = '';
          $scope.modal.datetimeNow = $scope.prepared.DateTimeNow;
          if ($scope.modal.genre !== $scope.prepared.GenreList[0].Value) $scope.modal.genre = $scope.prepared.GenreList[0].Value;
          if ($scope.modal.rating !== $scope.prepared.RatingList[0].Value) $scope.modal.rating = $scope.prepared.RatingList[0].Value;

          $scope.modal.addButton = true;
          $scope.modal.shareButton = false;
          $scope.modal.deleteButton = false;
          $scope.modal.saveButton = false;

          $("#AddModalWindow").modal("show");
      };
      $scope.addModalHide = function () {
          $("#AddModalWindow").modal("hide");
          $rootScope.closeModals();
      };
      //� ������ ������ ������� ��������� � ������������ ������, � ������ ��������
      function afterAdd() {
          $scope.addModalHide();
          $location.search('page', null);//� ������ �������� ����� �����
          $location.search('search', null);
          if ($stateParams) {
              $stateParams.page = null;
              $stateParams.search = null;
          }
          $scope.quickSearch.text = null;
          getMainPage();
      };
      //������� ������� ��������
      function afterSave() {
          $scope.addModalHide();
          getMainPage();
      };
      //������� ������ ��� �������� � ������ ���������� AddData
      $scope.modal.addButtonClick = function () {
          $rootScope.GetPage(constants.Pages.Add, $http, afterAdd, {
              pageId: pageId,
              name: $scope.modal.name,
              year: $scope.modal.year,
              authors: $scope.modal.authors,
              datetime: $('#modalFieldDateTime').val(),
              genre: $scope.modal.genre,
              rating: $scope.modal.rating
          });
      };
      //������� ��������� ��� ��������������
      $scope.modal.editButtonClick = function (id) {
          $scope.editedIndex = id;
          $scope.modal.title = $scope.translation.TitleEdit;
          $scope.modal.name = $scope.data[id].Name;
          $scope.modal.year = $scope.data[id].Year === 0 ? null : $scope.data[id].Year;
          $scope.modal.authors = $scope.data[id].Authors;
          $scope.modal.datetimeNow = $scope.data[id].DateReadText;
          if (parseInt($scope.modal.genre) !== parseInt($scope.data[id].Genre)) $scope.modal.genre = $scope.data[id].Genre;
          if (parseInt($scope.modal.rating) !== parseInt($scope.data[id].Rating)) $scope.modal.rating = $scope.data[id].Rating;

          $scope.modal.shareButton = true;
          $scope.modal.deleteButton = true;
          $scope.modal.saveButton = true;
          $scope.modal.addButton = false;

          $("#AddModalWindow").modal("show");
      };
      //��������� ����� ��������� ������
      $scope.modal.saveButtonClick = function () {
          $rootScope.GetPage(constants.Pages.Update, $http, afterSave, {
              pageId: pageId,
              id: $scope.data[$scope.editedIndex].Id,
              name: $scope.modal.name,
              year: $scope.modal.year,
              authors: $scope.modal.authors,
              datetime: $('#modalFieldDateTime').val(),
              genre: $scope.modal.genre,
              rating: $scope.modal.rating
          });
      };
      //��������� ����� ������� ������
      $scope.modal.deleteButtonClick = function () {
          $rootScope.GetPage(constants.Pages.Delete, $http, afterSave, { pageId: pageId, recordId: $scope.data[$scope.editedIndex].Id });
      };
      ///////////////////////////////////////////////////////////////////////
      ///////////////////////////////////////////////////////////////////////           ��������� �������
      ///////////////////////////////////////////////////////////////////////
      //��������� ����� �������� � ��������� �������
      function getShareCallBack(link) {
          $scope.modalShare.loading = false;
          if (link === '-') { //��� ������, �������� ������ - ��������
              $scope.modalShare.addButton = true;
              $scope.modalShare.link = '';
          } else { //���� ������, ��������, �������� ������ - ����������� + �������
              $scope.modalShare.tryButton = true;
              $scope.modalShare.deleteButton = true;
              $scope.modalShare.link = link;
          }
          getMainPage();
      };
      //����� ���������, �� ����� ���� �� ��������� ��������������, ����� �������� $scope.editedIndex (������ ������ �������� �������� �� 0, ��� if(0) ��� false)
      $scope.modalShare.shareButtonClick = function (id) {
          if (!id && id !== 0) id = $scope.editedIndex;

          $scope.editedIndex = id;
          $scope.modalShare.loading = true;

          $scope.modalShare.addButton = false;
          $scope.modalShare.tryButton = false;
          $scope.modalShare.deleteButton = false;

          $rootScope.GetPage(constants.Pages.GetShare, $http, getShareCallBack, { pageId: pageId, recordId: $scope.data[$scope.editedIndex].Id });

          $("#ShareModalWindow").modal("show");
      };
      //������ ������ ����������� � ��������� �������, ������� �� �������� ������� ������
      $scope.modalShare.tryButtonClick = function () {
          window.open($scope.modalShare.link, '_blank');
      };
      //������� ������ � ������� ������ �� ��������� �������
      $scope.modalShare.deleteButtonClick = function () {
          $scope.modalShare.loading = true;

          $scope.modalShare.addButton = false;
          $scope.modalShare.tryButton = false;
          $scope.modalShare.deleteButton = false;

          $rootScope.GetPage(constants.Pages.DeleteShare, $http, getShareCallBack, { pageId: pageId, recordId: $scope.data[$scope.editedIndex].Id });
      };
      //��������� ������ �� ��������� �������
      $scope.modalShare.addButtonClick = function () {
          $scope.modalShare.loading = true;

          $scope.modalShare.addButton = false;
          $scope.modalShare.tryButton = false;
          $scope.modalShare.deleteButton = false;

          $rootScope.GetPage(constants.Pages.GenerateShare, $http, getShareCallBack, { pageId: pageId, recordId: $scope.data[$scope.editedIndex].Id });
      };
  }]);

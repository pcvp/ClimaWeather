using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClimaWeather.ViewModels.Base {

    public class FormularioBaseModel : BaseViewModel, IDataErrorInfo {

        public List<ValidationResult> ValidarPropriedade(object objetoASerValidado, object propriedadeASerValidada, string nomeDoMembro) {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(objetoASerValidado, null, null);

            contexto.MemberName = nomeDoMembro;
            Validator.TryValidateProperty(propriedadeASerValidada, contexto, resultadoValidacao);
            return resultadoValidacao;
        }

        public List<ValidationResult> ErrosValidacao(object objetoASerValidado = null) {
            objetoASerValidado ??= this;
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(objetoASerValidado, null, null);
            Validator.TryValidateObject(objetoASerValidado, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }

        public string GetMensagemDeErroDaValidacaoSeExistir(List<ValidationResult> erros, string nomeDoCampo) {
            return erros.FirstOrDefault(f => f.MemberNames.Contains(nomeDoCampo)) != null
                ? erros.FirstOrDefault(f => f.MemberNames.Contains(nomeDoCampo)).ErrorMessage.ToString()
                : "";
        }

        #region IDataErrorInfo

        public string Error => throw new NotImplementedException();

        public string this[string columnName] => OnValidate(columnName);

        protected virtual string OnValidate(string propertyName) {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Invalid property name", propertyName);

            var value = this.GetType().GetProperty(propertyName).GetValue(this, null);
            var results = new List<ValidationResult>(1);

            var context = new ValidationContext(this, null, null) { MemberName = propertyName };

            var result = Validator.TryValidateProperty(value, context, results);

            var error = string.Empty;
            if (!result) {
                var validationResult = results.First();
                error = validationResult.ErrorMessage;
            }

            return error;
        }

        #endregion IDataErrorInfo
    }
}
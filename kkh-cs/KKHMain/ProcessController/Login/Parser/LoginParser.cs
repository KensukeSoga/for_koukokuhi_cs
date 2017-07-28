using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;

namespace Isid.KKH.Main.ProcessController.Login.Parser
{
    /// <summary>
    /// ���O�C���T�[�r�X�p�[�T�[
    /// </summary>
    /// <remarks>
    ///   �C���Ǘ�
    ///   <list type="table">
    ///     <listheader>
    ///       <description>���t</description>
    ///       <description>�C����</description>
    ///       <description>���e</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/02/24</description>
    ///       <description>JSE H.Abe</description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class LoginParser
    {
        #region ���\�b�h
        /// <summary>
        /// ���O�C�������擾���܂��B
        /// </summary>
        /// <param name="result">���O�C������</param>
        /// <returns>���O�C���p�[�X����</returns>
        internal static LoginParseResult ParseForLogin(loginResult result)
        {
            Schema.Login dsLogin = new Schema.Login();

            loginCustomerInfoVO[] loginCustomerInfoVOArray = result.loginCustomerInfoVOList;
            if (loginCustomerInfoVOArray != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsLogin.LoginCustomerData.TableName, loginCustomerInfoVOArray) };
                Schema.Login dsAddLogin = DataSetConverter.Convert<Schema.Login>(defs);
                dsLogin.LoginCustomerData.Merge(dsAddLogin.LoginCustomerData);
            }

            LoginParseResult parseResult = new LoginParseResult();
            parseResult.LoginCustomerDataSet = dsLogin;

            return parseResult;
        }

        #endregion
    }
}

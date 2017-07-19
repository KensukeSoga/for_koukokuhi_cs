package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �����ݒ�DAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementSettingDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private FindCostManagementSettingDAOFactory() {
    }

    /**
     * �����捞DAO�C���X�^���X�𐶐����܂�
     *
     * @return �����捞DAO�C���X�^���X
     */
    public static FindCostManagementCaptureDAO createFindCMCaptureDao() {
        return new FindCostManagementCaptureDAO();
    }

    /**
     * �����Ԏ�DAO�C���X�^���X�𐶐����܂�
     *
     * @return �����Ԏ�DAO�C���X�^���X
     */
    public static FindCostManagementCarDAO createFindCMCarDao() {
        return new FindCostManagementCarDAO();
    }

    /**
     * ������Ԏ�o�͐ݒ�DAO�C���X�^���X�𐶐����܂�
     *
     * @return ������Ԏ�o�͐ݒ�DAO�C���X�^���X
     */
    public static FindCostManagementCaroutctrlDAO createFindCMCaroutctrlDao() {
        return new FindCostManagementCaroutctrlDAO();
    }

    /**
     * �����(�o�̓I�v�V�����ȊO)DAO�C���X�^���X�𐶐����܂�
     *
     * @return �����(�o�̓I�v�V�����ȊO)DAO�C���X�^���X
     */
    public static FindCostManagementExceptOptDAO createFindCMExceptOptDao() {
        return new FindCostManagementExceptOptDAO();
    }

    /**
     * �ύX�m�F�f�[�^DAO�C���X�^���X���쐬���܂�
     * @return
     */
    public static FindAfterUptakeCheckDAO createFindAfterUptakeCheckDao() {
        return new FindAfterUptakeCheckDAO();
    }

}

package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC�}�̔�쐬DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/10 T.Fujiyoshi)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCMediaCreationDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private FindHCMediaCreationDAOFactory() {
    }

    /**
     * �}�́E���i�R�t���}�X�^�擾DAO�̃C���X�^���X�𐶐����܂�
     * @return �}�́E���i�R�t���}�X�^DAO
     */
    public static FindMediaProductDAO createFindMediaProductDao() {
        return new FindMediaProductDAO();
    }

    /**
     * �}�̔�Ǘ��擾DAO�̃C���X�^���X�𐶐����܂�
     * @return �}�̔�Ǘ��擾DAO
     */
    public static FindMediaMngDAO createFindMediaMngDao() {
        return new FindMediaMngDAO();
    }

    /**
     * �}�̔�ϖ��׊Ǘ��擾DAO�̃C���X�^���X�𐶐����܂�
     * @return �}�̔�ϖ��׊Ǘ��擾DAO
     */
    public static FindMediaMngEstDtlDAO createFindMediaMngEstDtlDao() {
        return new FindMediaMngEstDtlDAO();
    }

    /**
     * H�V���f���R�X�g���v�擾DAO�̃C���X�^���X�𐶐����܂�
     * @return H�V���f���R�X�g���v�擾DAO
     */
    public static FindSumHmCostDAO createFindSumHmCostDao() {
        return new FindSumHmCostDAO();
    }

    /**
     * ���ψČ�/���ϖ��׎擾DAO�̃C���X�^���X�𐶐����܂�
     * @return ���ψČ�/���ϖ��׎擾DAO
     */
    public static FindEstItemDtlDAO createFindEstItemDtlDao() {
        return new FindEstItemDtlDAO();
    }

    /**
     * �}�̔�Ǘ��o�^DAO�̃C���X�^���X�𐶐����܂�
     * @return �}�̔�Ǘ��o�^DAO
     */
    public static RegisterMediaMngDAO createRegisterMediaMngDao() {
        return new RegisterMediaMngDAO();
    }

    /**
     * HC���i�}�X�^�擾DAO�C���X�^���X�𐶐����܂�
     * @return HC���i�}�X�^�擾DAO
     */
    public static FindHCProductDAO createFindHCProductDAO() {
        return new FindHCProductDAO();
    }

    /**
     * ���ψČ��擾DAO�C���X�^���X�𐶐����܂�
     * @return ���ψČ��擾DAO
     */
    public static FindHCEstimateListItemDAO createFindHCEstimateListItemDao() {
        return new FindHCEstimateListItemDAO();
    }

    /**
     * ���Ϗڍ׎擾DAO�C���X�^���X�𐶐����܂�
     * @return ���Ϗڍ׎擾DAO
     */
    public static FindEstimateDetailDAO createFindEstimateDetailDao() {
        return new FindEstimateDetailDAO();
    }

    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
    /**
     * HM���Ϗ��A�������׏��쐬(�}��)�擾DAO�C���X�^���X�𐶐�����
     * @return FindHMEstimateMediaDAO HM���Ϗ��A�������׏��쐬(�}��)�擾DAO�C���X�^���X
     */
    public static FindHMEstimateMediaReportDAO createHMEstimateMediaReportDao() {
        return new FindHMEstimateMediaReportDAO();
    }

    /**
     * HM�������쐬(�}��)�擾DAO�C���X�^���X�𐶐�����
     * @return HM�������쐬(�}��)�擾DAO�C���X�^���X
     */
    public static FindHMBillMediaReportDAO createHMBillMediaReportDao() {
        return new FindHMBillMediaReportDAO();
    }

    /**
     * HM���v�������쐬(�}��)�擾DAO�C���X�^���X�𐶐�����
     * @return FindHMBillTotalMediaReport HM���v�������쐬(�}��)�擾DAO�C���X�^���X
     */
    public static FindHMBillTotalMediaReportDAO createFindHMBillTotalMediaReportDao() {
        return new FindHMBillTotalMediaReportDAO();
    }
    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

}

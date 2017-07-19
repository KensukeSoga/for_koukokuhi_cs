package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC���ψꗗ�擾DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/4 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private FindHCEstimateListDAOFactory() {
    }

    /**
     * HC���ψꗗ(���쌴��)�擾DAO�C���X�^���X�𐶐����܂�
     *
     * @return HC���ψꗗ(���쌴��)�擾DAO
     */
    public static FindHCEstimateListCostDAO createFindHCEstimateListCostDao() {
        return new FindHCEstimateListCostDAO();
    }

    /**
     * HC���ψꗗ(�����)�擾DAO�C���X�^���X�𐶐����܂�
     *
     * @return HC���ψꗗ(�����)�擾DAO
     */
    public static FindHCEstimateListTotalDAO createFindHCEstimateListTotalDao() {
        return new FindHCEstimateListTotalDAO();
    }

    /**
     * HC���ψꗗ(���ψČ�)�擾DAO�C���X�^���X�𐶐����܂�
     *
     * @return HC���ψꗗ(���ψČ�)�擾DAO
     */
    public static FindHCEstimateListItemDAO createFindHCEstimateListItemDao() {
        return new FindHCEstimateListItemDAO();
    }
}

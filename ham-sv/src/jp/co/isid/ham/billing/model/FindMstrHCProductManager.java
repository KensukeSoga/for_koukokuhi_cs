package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj08HcProductCondition;
import jp.co.isid.ham.common.model.Mbj08HcProductDAO;
import jp.co.isid.ham.common.model.Mbj08HcProductDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * HC���i�}�X�^���擾����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMstrHCProductManager {

    /** �V���O���g���C���X�^���X */
    private static FindMstrHCProductManager _manager = new FindMstrHCProductManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindMstrHCProductManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static FindMstrHCProductManager getInstance() {
        return _manager;
    }

    /**
     * ���i�}�X�^�擾(���i�R�[�h����͎�)
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindMstrHCProductResult findMstrHCProduct(Mbj08HcProductCondition cond) throws HAMException {

        FindMstrHCProductResult result = new FindMstrHCProductResult();

        Mbj08HcProductDAO mbj08Dao = Mbj08HcProductDAOFactory.createMbj08HcProductDAO();
        result.setProduct(mbj08Dao.selectVO(cond));

        return result;
    }

    /**
     * HC���i�}�X�^����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindHCProductResult findHCProduct(FindHCProductCondition cond) throws HAMException {

        FindHCProductResult result = new FindHCProductResult();

        // HC���i�}�X�^�擾
        FindHCProductDAO productDao = FindHCEstimateCreationDAOFactory.createFindHCProductDao();
        result.setProduct(productDao.selectVO(cond));

        return result;
    }

}

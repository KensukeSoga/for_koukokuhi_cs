package jp.co.isid.ham.media.model;

import java.util.List;
import java.util.ArrayList;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindOrderSelectManager {

    /** �V���O���g���C���X�^���X */
    private static FindOrderSelectManager _manager = new FindOrderSelectManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindOrderSelectManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindOrderSelectManager getInstance() {
        return _manager;
    }


    /**
     * �c�ƍ�Ƒ䒠��������
     * @return FindOrderSelectResult �c�ƍ�Ƒ䒠���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindOrderSelectResult findOrderSelect(FindOrderSelectCondition cond)
            throws HAMException {

        //��������
        FindOrderSelectResult result = new FindOrderSelectResult();

        // ******************************************************
        // �c�ƍ�Ƒ䒠���̎擾
        // ******************************************************
        FindOrderSelectDAO orderdao = FindOrderSelectDAOFactory.createOrderSelectDAOFactory();

        List<FindOrderSelectVO> tmpList = orderdao.FindOrderSelect(cond);
        List<FindOrderSelectVO> retList = new ArrayList<FindOrderSelectVO>();
        for (FindOrderSelectVO getvo:tmpList)
        {
            RepaVbjaMeu20MsMzBtDAO msmzbtdao = RepaVbjaMeu20MsMzBtDAOFactory.createRepaVbjaMeu20MsMzBtDAO();
            RepaVbjaMeu20MsMzBtCondition msmzbtcond = new RepaVbjaMeu20MsMzBtCondition();

            int lenMediasCd = getvo.getMEDIASCD().length();

            //�}�̎�ʃR�[�h�ƌ��ŃR�[�h�𕪉�
            if (lenMediasCd != 6)
            {   // �}�̎�ʃR�[�h��6���łȂ��ꍇ�͖���
                continue;
            }
            String mediaCd = getvo.getMEDIASCD().substring(0,lenMediasCd - 2);
            String kbanCd = getvo.getMEDIASCD().substring(lenMediasCd - 2, lenMediasCd);

            msmzbtcond.setSzkbn("A");   // �V��
            msmzbtcond.setSinzatsubtaicd(mediaCd);
            msmzbtcond.setKbancd(kbanCd);
            List<RepaVbjaMeu20MsMzBtVO> getmsmzbtlist = msmzbtdao.selectVO(msmzbtcond);
            if ((getmsmzbtlist == null) || (getmsmzbtlist.size() == 0))
            {   // �}�̎�ʃR�[�h�ɊY�������V�G�}�̃}�X�^���Ȃ��ꍇ�͖����Ƃ���
                continue;
            }

            retList.add(getvo);

        }
        result.setOrderSelect(retList);

        // ******************************************************
        // ��ʍ��ڕ\���񐧌�}�X�^�擾
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        return result;
    }
}

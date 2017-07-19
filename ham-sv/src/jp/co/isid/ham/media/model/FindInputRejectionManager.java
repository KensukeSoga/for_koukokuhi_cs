package jp.co.isid.ham.media.model;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindInputRejectionManager {

    /** �V���O���g���C���X�^���X */
    private static FindInputRejectionManager _manager = new FindInputRejectionManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindInputRejectionManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindInputRejectionManager getInstance() {
        return _manager;
    }

    /**
     * ���͋��ۏ����������܂�
     *
     * @return FindInputRejectionResult ���͋��ۏ��
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindInputRejectionResult findInputRejection(FindInputRejectionCondition cond)
    throws HAMException {

        //��������
        FindInputRejectionResult result = new FindInputRejectionResult();

        //*******************************************
        //�}�̏󋵊Ǘ��f�[�^���������܂�.
        //*******************************************
        FindInputRejectionDAO fdao = FindInputRejectionDAOFactory.createFindInputRejectionDAO();
        List<FindInputRejectionVO> dlist = fdao.findMediaPlanInputRejection(cond.getCampCd());
        result.setInputReject(dlist);

        //*******************************************
        //�c�ƍ�Ƒ䒠���������܂�.
        //*******************************************
        //�܂��͔}�̏󋵊Ǘ����������A�}�̊Ǘ�No�̎擾���s���܂�.
        Tbj01MediaPlanDAO mdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mlist = mdao.findMediaPlanByCampCd(cond.getCampCd());
        Tbj02EigyoDaichoDAO edao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy/MM");
        ArrayList<FindInputRejectionVO> addListvo = new ArrayList<FindInputRejectionVO>();
        for (Tbj01MediaPlanVO mvo : mlist) {
            List<Tbj02EigyoDaichoVO> elist = edao.FindEigyoDaichoByMediaPlanNo(mvo.getMEDIAPLANNO().toString());
            if (elist.size() != 0) {
                FindInputRejectionVO addvo = new FindInputRejectionVO();
                addvo.setMEDIACD(mvo.getMEDIACD());
                addvo.setYOTEIYM(sdf1.format(mvo.getYOTEIYM()));
                addListvo.add(addvo);
            }
        }
        result.setInputRejectByEigyo(addListvo);

        return result;
    }

}

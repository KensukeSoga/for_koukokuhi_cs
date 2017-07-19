package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * ���쌴���ύX�_�擾
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindProductionChangeCheckResult extends AbstractServiceResult{

    /** �쐬���f�[�^ */
    List<FindBeforeProductionVO> _bp;

    /** ���݃f�[�^ */
    List<FindNowProductionVO> _np;

    /** ��ʍ��ڕ\���񐧌�}�X�^ */
    List<Mbj37DisplayControlVO> _dc;

    /**
     * �쐬���f�[�^���擾
     * @return
     */
    public List<FindBeforeProductionVO> getBeforeProduction() {
        return _bp;
    }

    /**
     * �쐬���f�[�^��ݒ�
     * @param bp
     */
    public void setBeforeProduction(List<FindBeforeProductionVO> bp) {
        this._bp = bp;
    }

    /**
     * ���݃f�[�^���擾
     * @return
     */
    public List<FindNowProductionVO> getNowProduction() {
        return _np;
    }

    /**
     * ���݃f�[�^��ݒ�
     * @param np
     */
    public void setNowProduction(List<FindNowProductionVO> np) {
        this._np = np;
    }

    /**
     * ��ʍ��ڕ\���񐧌�}�X�^���擾����
     *
     * @return ��ʍ��ڕ\���񐧌�}�X�^
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * ��ʍ��ڕ\���񐧌�}�X�^��ݒ肷��
     *
     * @param dc ��ʍ��ڕ\���񐧌�}�X�^
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }
}

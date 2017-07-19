package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu14ThsTntTrVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu20MsMzBtVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
* <P>
* DKB�A�g�t�@�C���o�͗p�̏���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/02/19 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindCooperationDataResult extends AbstractServiceResult {

    /** �g�D�f�[�^VO */
    private List<FindSocietyDataVO> _societyVO;

    /** ����S��VO */
    private List<RepaVbjaMeu14ThsTntTrVO> _charge;

    /** �V�G�}��VO */
    private List<RepaVbjaMeu20MsMzBtVO> _mediaVO;

    /** �R�[�h�}�X�^VO */
    private List<RepaVbjaMeu29CcVO> _codeMasterVO;

    /** �R�[�h�}�X�^VO(HAM) */
    private List<Mbj12CodeVO> _codeVO;

    /** ���VO */
    private List<FindItemVO> _itemVO;

    /** �l�����敪VO */
    private List<FindDiscountFlgVO> _discFlgVO;

    /** �X�y�[�X(�X�y�[�X�̃J�����ɓ��͉\�Ȓl�Ƃ��̃R�[�h) */
    private List<RepaVbjaMeu29CcVO> _space;


    /**
     * �g�D�f�[�^�擾
     * @return
     */
    public List<FindSocietyDataVO> getSocietyData() {
        return _societyVO;
    }

    /**
     * �g�D�f�[�^�ݒ�
     * @param societyVO
     */
    public void setSocietyData(List<FindSocietyDataVO> societyVO) {
        this._societyVO = societyVO;
    }

    /**
     * ����S���擾
     * @return
     */
    public List<RepaVbjaMeu14ThsTntTrVO> getRepaVbjaMeu14ThsTntTr() {
        return _charge;
    }

    /**
     * ����S���ݒ�
     * @param charge
     */
    public void setRepaVbjaMeu14ThsTntTr(List<RepaVbjaMeu14ThsTntTrVO> charge) {
        this._charge = charge;
    }

    /**
     * �V�G�}�̎擾
     * @return
     */
    public List<RepaVbjaMeu20MsMzBtVO> getRepaVbjaMeu20MsMzBtVO() {
        return _mediaVO;
    }

    /**
     * �V�G�}�̐ݒ�
     * @param mediaVO
     */
    public void setRepaVbjaMeu20MsMzBtVO(List<RepaVbjaMeu20MsMzBtVO> mediaVO) {
        this._mediaVO = mediaVO;
    }

    /**
     * �R�[�h�}�X�^�擾
     * @return
     */
    public List<RepaVbjaMeu29CcVO> getRepaVbjaMeu29CcVO() {
        return _codeMasterVO;
    }

    /**
     * �R�[�h�}�X�^�ݒ�
     * @param codeMasterVO
     */
    public void setRepaVbjaMeu29CcVO(List<RepaVbjaMeu29CcVO> codeMasterVO) {
        this._codeMasterVO = codeMasterVO;
    }

    /**
     * �R�[�h�}�X�^(HAM)�擾
     * @return
     */
    public List<Mbj12CodeVO> getMbj12Code() {
        return _codeVO;
    }

    /**
     * �R�[�h�}�X�^(HAM)�ݒ�
     * @param codeVO
     */
    public void setMbj12Code(List<Mbj12CodeVO> codeVO) {
        this._codeVO = codeVO;
    }

    /**
     * ��ڎ擾
     * @return
     */
    public List<FindItemVO> getItem() {
        return _itemVO;
    }

    /**
     * ��ڐݒ�
     * @param itemVO
     */
    public void setItem(List<FindItemVO> itemVO) {
        this._itemVO = itemVO;
    }

    /**
     * �l�����敪�擾
     * @return
     */
    public List<FindDiscountFlgVO> getDiscountFlg() {
        return _discFlgVO;
    }

    /**
     * �l�����敪�ݒ�
     * @param discFlg
     */
    public void setDiscountFlg(List<FindDiscountFlgVO> discFlg) {
        this._discFlgVO = discFlg;
    }

    /**
     * �X�y�[�X�擾
     * @return �X�y�[�X
     */
    public List<RepaVbjaMeu29CcVO> getSpace() {
        return _space;
    }

    /**
     * �X�y�[�X�ݒ�
     * @param space �X�y�[�X
     */
    public void setSpace(List<RepaVbjaMeu29CcVO> space) {
        _space = space;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}

package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* �������׏��o�͉�ʏ���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2012/12/20 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindBillStatementResult extends AbstractServiceResult{

    /** �Ԏ�̏��擾 */
    private List<CarListVO> _cl;

    /** �ŏI�X�V�ҏ��̎擾 */
    private List<Tbj02EigyoDaichoVO> _daicho;

    /** �@�\����Info */
    private List<FunctionControlInfoVO> _funcinfo;

    /**
     * �Ԏ�ꗗ���擾����
     *
     * @return �Ԏ�ꗗ
     */
    public List<CarListVO> getCarList() {
        return _cl;
    }

    /**
     * �Ԏ�ꗗ��ݒ肷��
     *
     * @param dc �Ԏ�ꗗ
     */
    public void setCarList(List<CarListVO> cl) {
        _cl = cl;
    }

    /**
     * �ŏI�X�V�ҏ����擾���܂�
     * @return _daicho
     */
    public List<Tbj02EigyoDaichoVO> getTbj02EigyoDaicho() {
        return _daicho;
    }

    /**
     * �ŏI�X�V�ҏ���ݒ肵�܂�
     * @param daicho
     */
    public void setTbj02EigyoDaicho(List<Tbj02EigyoDaichoVO> daicho) {
        _daicho = daicho;
    }

    /**
     * �@�\����InfoVO���X�g���擾����
     * @return �@�\����InfoVO���X�g
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * �@�\����InfoVO���X�g��ݒ肷��
     * @param secinfo �@�\����InfoVO���X�g
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
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

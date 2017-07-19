package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* �L�����y�[���ꗗ�̏���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2012/11/30 FM h.izawa)<BR>
* </P>
* @author FM H.Izawa
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindCampaignListResult extends AbstractServiceResult {

    /** �L�����y�[���ꗗ�̎擾 */
    private List<Tbj12CampaignVO> _cam;

    /** �Ԏ�ꗗ�̎擾 */
    private List<CarListVO> _car;

    /** �Ԏ�ꗗ�̎擾 */
    private List<Tbj12CampaignVO> _camDetail;

    /**�X�v���b�h�ꗗ�擾*/
    private List<Mbj37DisplayControlVO> _spdControl;

    /** �Z�L�����e�BInfo */
    private List<SecurityInfoVO> _secinfo;

    /** �@�\����Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * �L�����y�[���ꗗVO���X�g���擾���܂�
     * @return _cam
     */
    public List<Tbj12CampaignVO> getCampaignList() {
        return _cam;
    }

    /**
     * �L�����y�[���ꗗVO���X�g��ݒ肵�܂�
     * @param _cam �Z�b�g���� _cam
     */
    public void setCampaignList(List<Tbj12CampaignVO> cam) {
        _cam = cam;
    }

    /**
     * �Ԏ�ꗗVO���X�g���擾���܂�
     * @return _car
     */
    public List<CarListVO> getCarList() {
        return _car;
    }

    /**
     * �Ԏ�ꗗVO���X�g��ݒ肵�܂�
     * @param _car �Z�b�g���� _car
     */
    public void setCarList(List<CarListVO> car) {
        _car = car;
    }

    /**
     * �L�����y�[���ꗗ�Əڍׂ��R���Ă���f�[�^���擾���܂�
     * @return _camDetail
     */
    public List<Tbj12CampaignVO> get_camDetail() {
        return _camDetail;
    }

    /**
     * �L�����y�[���ꗗ�Əڍׂ��R���Ă���f�[�^��ݒ肵�܂�
     * @param _camDetail �Z�b�g���� _camDetail
     */
    public void set_camDetail(List<Tbj12CampaignVO> _camDetail) {
        this._camDetail = _camDetail;
    }

    /**
     *�X�v���b�h�ꗗVO���X�g���擾���܂�
     * @return _cam
     */
    public List<Mbj37DisplayControlVO> getSpdControl() {
        return _spdControl;
    }

    /**
     *�X�v���b�h�ꗗVO���X�g��ݒ肵�܂�
     * @param _cam �Z�b�g���� _cam
     */
    public void setSpdControl(List<Mbj37DisplayControlVO> spdControl) {
        _spdControl = spdControl;
    }

    /**
     * �Z�L�����e�BInfoVO���X�g���擾����
     * @return �Z�L�����e�BInfoVO���X�g
     */
    public List<SecurityInfoVO> getSecurityInfoVoList() {
        return _secinfo;
    }

    /**
     * �Z�L�����e�BInfoVO���X�g��ݒ肷��
     * @param secinfo �Z�L�����e�BInfoVO���X�g
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> secinfo) {
        _secinfo = secinfo;
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

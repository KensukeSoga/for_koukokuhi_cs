package jp.co.isid.ham.media.model;

import java.io.Serializable;

import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;

import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class MediaPlanRegisterCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**�}�̏󋵊Ǘ��o�^�pVO */
    private List<Tbj01MediaPlanVO> _insVo;
    /**�}�̏󋵊Ǘ��X�V�pVO */
    private List<Tbj01MediaPlanVO> _delVo;
    /**�}�̏󋵊Ǘ��폜�pVO */
    private List<Tbj01MediaPlanVO> _updVo;
    /**�L�����y�[���ڍדo�^�pVO */
    private List<Tbj13CampDetailVO> _deInsVo;
    /**�L�����y�[���ڍ׍폜�pVO */
    private List<Tbj13CampDetailVO> _deDelVo;
    /**�L�����y�[���ڍ׍X�V�pVO */
    private List<Tbj13CampDetailVO> _deUpdVo;

    /**�}�̍č쐬��̓o�^���̃t���O(true:�}�̖��쐬��:false:�}�̍č쐬��)*/
    private boolean _insOnlyFlg;

    /**HamID*/
    private String _hamId;

    /**���[�U��*/
    private String _hamNm;

    /**�X�V�v���O����*/
    private String _updApl;

    /** �_�~�[�v���p�e�B */
    private String _dummy;

    /**�f�[�^�J�E���g*/
    private int _dataCount;

    /**�ŏI�X�V��ID*/
    private String _latestupdId;

    /**�ŏI�X�V����*/
    private Date _latestDate;

    /**
     * @return insVo
     */
    public List<Tbj01MediaPlanVO> getInsVo() {
        return _insVo;
    }
    /**
     * @param insVo �Z�b�g���� insVo
     */
    public void setInsVo(List<Tbj01MediaPlanVO> insVo) {
        this._insVo = insVo;
    }

    /**
     * @return _delVo
     */
    public List<Tbj01MediaPlanVO> getDelVo() {
        return _delVo;
    }
    /**
     * @param _delVo �Z�b�g���� _delVo
     */
    public void setDelVo(List<Tbj01MediaPlanVO> delVo) {
        this._delVo = delVo;
    }

    /**
     * @return updVo
     */
    public List<Tbj01MediaPlanVO> getUpdVo() {
        return _updVo;
    }
    /**
     * @param updVo �Z�b�g���� updVo
     */
    public void setUpdVo(List<Tbj01MediaPlanVO> updVo) {
        this._updVo = updVo;
    }

    /**
     * @return deInsVo
     */
    public List<Tbj13CampDetailVO> getDeInsVo() {
        return _deInsVo;
    }
    /**
     * @param deInsVo �Z�b�g���� deInsVo
     */
    public void setDeInsVo(List<Tbj13CampDetailVO> deInsVo) {
        this._deInsVo = deInsVo;
    }


    /**
     * @return deDelVo
     */
    public List<Tbj13CampDetailVO> getDeDelVo() {
        return _deDelVo;
    }
    /**
     * @param deDelVo �Z�b�g���� deDelVo
     */
    public void setDeDelVo(List<Tbj13CampDetailVO> deDelVo) {
        this._deDelVo = deDelVo;
    }

    /**
     * @return deUpdVo
     */
    public List<Tbj13CampDetailVO> getDeUpdVo() {
        return _deUpdVo;
    }
    /**
     * @param deUpdVo �Z�b�g���� deUpdVo
     */
    public void setDeUpdVo(List<Tbj13CampDetailVO> deUpdVo) {
        this._deUpdVo = deUpdVo;
    }

    /**
     * @return insOnlyFlg
     */
    public boolean getInsOnlyFlg() {
        return _insOnlyFlg;
    }
    /**
     * @param insOnlyFlg �Z�b�g���� insOnlyFlg
     */
    public void setInsOnlyFlg(boolean insOnlyFlg) {
        this._insOnlyFlg = insOnlyFlg;
    }
    /**
     * @return hamId
     */
    public String getHamId() {
        return _hamId;
    }
    /**
     * @param hamId �Z�b�g���� hamId
     */
    public void setHamId(String hamId) {
        this._hamId = hamId;
    }

    /**
     * @return hamNm
     */
    public String getHamNm() {
        return _hamNm;
    }
    /**
     * @param hamNm �Z�b�g���� hamNm
     */
    public void setHamNm(String hamNm) {
        this._hamNm = hamNm;
    }


    /**
     * @return updApl
     */
    public String getUpdApl() {
        return _updApl;
    }
    /**
     * @param updApl �Z�b�g���� updApl
     */
    public void setUpdApl(String updApl) {
        this._updApl = updApl;
    }


    /**
     * �_�~�[�v���p�e�B��Ԃ��܂�
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * �_�~�[�v���p�e�B��ݒ肷��
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
    }

    /**
     * �f�[�^�J�E���g���擾����
     * @return �f�[�^�J�E���g
     */
    public int getDataCount() {
        return _dataCount;
    }
    /**
     * �f�[�^�J�E���g��ݒ肷��
     * @param dataCount �f�[�^�J�E���g
     */
    public void setDataCount(int dataCount) {
        this._dataCount = dataCount;
    }

    /**
     * �ŏI�X�V��ID���擾����
     * @return �ŏI�X�V��ID
     */
    public String getLatestUpdId() {
        return _latestupdId;
    }
    /**
     * �ŏI�X�V��ID��ݒ肷��
     * @param latestupdId �ŏI�X�V��ID
     */
    public void setLatestUpdId(String latestupdId) {
        this._latestupdId = latestupdId;
    }

    /**
     * �ŏI�X�V�����擾����
     *
     * @return �ŏI�X�V��
     */
    @XmlElement(required = true)
    public Date getLatestDate() {
        return _latestDate;
    }

    /**
     * �ŏI�X�V�����擾����
     *
     * @param _latestDate �ŏI�X�V��
     */
    public void setLatestDate(Date latestDate) {
        this._latestDate = latestDate;
    }
}
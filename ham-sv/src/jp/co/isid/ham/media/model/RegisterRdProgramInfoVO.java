package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialVO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;

/**
 * <P>
 * ���W�I�ԑg�o�^��ʓo�^���VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RegisterRdProgramInfoVO implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���W�I�ԑg�ꗗ�o�^�pVO */
    private List<Tbj37RdProgramVO> _tbj37InsVo = null;
    /** ���W�I�ԑg�ꗗ�X�V�pVO */
    private List<Tbj37RdProgramVO> _tbj37UpdVo = null;
    /** ���W�I�ԑg�ꗗ�폜�pVO */
    private List<Tbj37RdProgramVO> _tbj37DelVo = null;

    /** ���W�I�ԑg�f�ޓo�^�pVO */
    private List<Tbj38RdProgramMaterialVO> _tbj38InsVo = null;
    /** ���W�I�ԑg�f�ލX�V�pVO */
    private List<Tbj38RdProgramMaterialVO> _tbj38UpdVo = null;
    /** ���W�I�ԑg�f�ލ폜�pVO */
    private List<Tbj38RdProgramMaterialVO> _tbj38DelVo = null;

    /** ���W�I�ԑg�l�b�g�Ǔo�^�pVO */
    private List<Tbj39RdProgramStationVO> _tbj39InsVo = null;
    /** ���W�I�ԑg�l�b�g�Ǎ폜�pVO */
    private List<Tbj39RdProgramStationVO> _tbj39DelVo = null;

    /** �f�ވꗗ�X�V�pVO */
    private List<Tbj20SozaiKanriListVO> _tbj20UpdVo = null;

    /** �S����ID */
    private String _hamid = null;

    /** �_�~�[�v���p�e�B */
    private String _dummy;

    /**
     * ���W�I�ԑg�ꗗ�o�^�pVO���擾����
     * @return List<Tbj37RdProgramVO> ���W�I�ԑg�ꗗ�o�^�pVO
     */
    public List<Tbj37RdProgramVO> getTbj37InsVo() {
        return _tbj37InsVo;
    }

    /**
     * ���W�I�ԑg�ꗗ�o�^�pVO��ݒ肷��
     * @param vo List<Tbj37RdProgramVO> ���W�I�ԑg�ꗗ�o�^�pVO
     */
    public void setTbj37InsVo(List<Tbj37RdProgramVO> vo) {
        _tbj37InsVo = vo;
    }

    /**
     * ���W�I�ԑg�ꗗ�X�V�pVO���擾����
     * @return List<Tbj37RdProgramVO> ���W�I�ԑg�ꗗ�X�V�pVO
     */
    public List<Tbj37RdProgramVO> getTbj37UpdVo() {
        return _tbj37UpdVo;
    }

    /**
     * ���W�I�ԑg�ꗗ�X�V�pVO��ݒ肷��
     * @param vo List<Tbj37RdProgramVO> ���W�I�ԑg�ꗗ�X�V�pVO
     */
    public void setTbj37UpdVo(List<Tbj37RdProgramVO> vo) {
        _tbj37UpdVo = vo;
    }

    /**
     * ���W�I�ԑg�ꗗ�폜�pVO���擾����
     * @return List<Tbj37RdProgramVO> ���W�I�ԑg�ꗗ�폜�pVO
     */
    public List<Tbj37RdProgramVO> getTbj37DelVo() {
        return _tbj37DelVo;
    }

    /**
     * ���W�I�ԑg�ꗗ�폜�pVO��ݒ肷��
     * @param vo List<Tbj37RdProgramVO> ���W�I�ԑg�ꗗ�폜�pVO
     */
    public void setTbj37DelVo(List<Tbj37RdProgramVO> vo) {
        _tbj37DelVo = vo;
    }

    /**
     * ���W�I�ԑg�f�ޓo�^�pVO���擾����
     * @return List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�f�ޓo�^�pVO
     */
    public List<Tbj38RdProgramMaterialVO> getTbj38InsVo() {
        return _tbj38InsVo;
    }

    /**
     * ���W�I�ԑg�f�ޓo�^�pVO��ݒ肷��
     * @param vo List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�f�ޓo�^�pVO
     */
    public void setTbj38InsVo(List<Tbj38RdProgramMaterialVO> vo) {
        _tbj38InsVo = vo;
    }

    /**
     * ���W�I�ԑg�f�ލX�V�pVO���擾����
     * @return List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�f�ލX�V�pVO
     */
    public List<Tbj38RdProgramMaterialVO> getTbj38UpdVo() {
        return _tbj38UpdVo;
    }

    /**
     * ���W�I�ԑg�f�ލX�V�pVO��ݒ肷��
     * @param vo List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�f�ލX�V�pVO
     */
    public void setTbj38UpdVo(List<Tbj38RdProgramMaterialVO> vo) {
        _tbj38UpdVo = vo;
    }

    /**
     * ���W�I�ԑg�f�ލ폜�pVO���擾����
     * @return List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�f�ލ폜�pVO
     */
    public List<Tbj38RdProgramMaterialVO> getTbj38DelVo() {
        return _tbj38DelVo;
    }

    /**
     * ���W�I�ԑg�f�ލ폜�pVO��ݒ肷��
     * @param vo List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�f�ލ폜�pVO
     */
    public void setTbj38DelVo(List<Tbj38RdProgramMaterialVO> vo) {
        _tbj38DelVo = vo;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǔo�^�pVO���擾����
     * @return List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǔo�^�pVO
     */
    public List<Tbj39RdProgramStationVO> getTbj39InsVo() {
        return _tbj39InsVo;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǔo�^�pVO��ݒ肷��
     * @param vo List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǔo�^�pVO
     */
    public void setTbj39InsVo(List<Tbj39RdProgramStationVO> vo) {
        _tbj39InsVo = vo;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǎ폜�pVO���擾����
     * @return List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǎ폜�pVO
     */
    public List<Tbj39RdProgramStationVO> getTbj39DelVo() {
        return _tbj39DelVo;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǎ폜�pVO��ݒ肷��
     * @param vo List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǎ폜�pVO
     */
    public void setTbj39DelVo(List<Tbj39RdProgramStationVO> vo) {
        _tbj39DelVo = vo;
    }

    /**
     * �f�ވꗗ�X�V�pVO���擾����
     * @return List<Tbj20SozaiKanriListVO> �f�ވꗗ�X�V�pVO
     */
    public List<Tbj20SozaiKanriListVO> getTbj20UpdVo() {
        return _tbj20UpdVo;
    }

    /**
     * �f�ވꗗ�X�V�pVO��ݒ肷��
     * @param vo List<Tbj20SozaiKanriListVO> �f�ވꗗ�X�V�pVO
     */
    public void setTbj20UpdVo(List<Tbj20SozaiKanriListVO> vo) {
        _tbj20UpdVo = vo;
    }

    /**
     * �S����ID���擾����
     * @return String �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     * @param val String �S����ID
     */
    public void setHamid(String val) {
        _hamid = val;
    }

    /**
     * �_�~�[�v���p�e�B��Ԃ��܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * �_�~�[�v���p�e�B��ݒ肷��
     * @param val String �_�~�[�v���p�e�B
     */
    public void set_dummy(String val) {
        _dummy = val;
    }
}
